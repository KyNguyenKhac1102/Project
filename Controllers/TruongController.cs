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
    public class TruongController : Controller
    {
        private readonly ITruongService _truongService;

        public TruongController(ITruongService truongService)
        {
            _truongService = truongService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var truongs = await _truongService.GetTruongs();
            return Ok(truongs);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var truong = await _truongService.GetTruongById(id);
            return Ok(truong);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TruongDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var truong = await _truongService.Create(dto);

            if (truong != null)
                return Created("/api/Truong", truong);
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TruongDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _truongService.Update(id, dto);
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
                var deleteCheck = await _truongService.Delete(id);
                return Ok(deleteCheck);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}