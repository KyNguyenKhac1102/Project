using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NganhController : Controller
    {
        private readonly INganhService _nganhService;

        public NganhController(INganhService nganhService)
        {
            _nganhService = nganhService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var nganhs = await _nganhService.GetNganhs();
            return Ok(nganhs);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string maNganh)
        {
            var nganh = await _nganhService.GetNganhById(maNganh);
            return Ok(nganh);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NganhDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var nganh = await _nganhService.Create(dto);

            if (nganh != null)
                return Created("/api/Nganh", nganh);
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string maNganh, NganhDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _nganhService.Update(maNganh, dto);
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string maNganh)
        {

            try
            {
                var deleteCheck = await _nganhService.Delete(maNganh);
                return Ok(deleteCheck);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}