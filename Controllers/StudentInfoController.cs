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
    public class StudentInfoController : Controller
    {
        private readonly IStudentInfoService _studentInfoService;

        public StudentInfoController(IStudentInfoService studentInfoService)
        {
            _studentInfoService = studentInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var studentInfos = await _studentInfoService.GetStudentInfos();
            return Ok(studentInfos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var studentInfo = await _studentInfoService.GetInfoById(id);
            return Ok(studentInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentInfoDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var studentInfo = await _studentInfoService.Create(dto);
                return Created("/api/StudentInfo", studentInfo);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }


        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, StudentInfoDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _studentInfoService.Update(id, dto);
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
                var deleteCheck = await _studentInfoService.Delete(id);
                return Ok(deleteCheck);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}