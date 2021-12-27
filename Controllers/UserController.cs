using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.Rest.Verify.V2.Service;
using Project.Services;
using System.Threading;
using Project.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IConfiguration _config;
        private readonly IUserService _userSerivce;

        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userSerivce = userService;
        }
        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                    new Claim("PhoneNumber", user.PhoneNumber),
                    // new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(JwtRegisteredClaimNames.Sub , user.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken ValidateCurrentToken(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }

        private string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }

        // [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var users = await _userSerivce.GetUsers(cancellationToken);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userSerivce.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("private")]

        public async Task<IActionResult> PrivatePost(RegisterDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userSerivce.Create(dto);

            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created("/api/User", user);
        }

        [HttpPost("public")]

        public async Task<IActionResult> PublicPost([FromBody] RegisterDtos dto, string code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var accountId = _config["TwilioAccountSid"];
                var authToken = _config["TwilioAuthToken"];
                TwilioClient.Init(accountId, authToken);

                var verificationCheck = await VerificationCheckResource.CreateAsync(
                    to: $"+84{dto.PhoneNumber}",
                    code: code,
                   pathServiceSid: "VAbee8d032ff0b1e9d7f6021aad4ae0743"
                );

                if (verificationCheck.Status == "approved")
                {
                    var user = await _userSerivce.Create(dto);
                    return Created("/api/User", user);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserUpdateDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _userSerivce.Update(id, dto);
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var deleteCheck = await _userSerivce.Delete(id);
                return Ok(deleteCheck);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("sendSMS")]
        public async Task<IActionResult> SendSms(string phone)
        {
            var accountId = _config["TwilioAccountSid"];
            var authToken = _config["TwilioAuthToken"];
            TwilioClient.Init(accountId, authToken);


            var verification = await VerificationResource.CreateAsync(
                to: $"+84{phone}",
                channel: "sms",
                pathServiceSid: "VAbee8d032ff0b1e9d7f6021aad4ae0743"
            );

            return Ok(verification);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDtos dto)
        {
            var user = await _userSerivce.GetUserByPhone(dto.PhoneNumber);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid phone number!!" });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid phone password!!" });
            }

            var jwt = GenerateJSONWebToken(user);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {

            });

            return Ok(jwt);
        }

        [HttpGet("VerifyJwt")]
        public async Task<IActionResult> Jwt()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = ValidateCurrentToken(jwt);

                string phone = token.Claims.First(claim => claim.Type == "PhoneNumber").Value;
                var user = await _userSerivce.GetUserByPhone(phone);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

        }
        // [Authorize]
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            var jwt = Request.Cookies["jwt"];
            if (jwt != null)
            {
                Response.Cookies.Delete("jwt");
                return Ok(new { message = "Log Out!" });
            }
            else
            {
                return BadRequest();
            }


        }



    }
}
