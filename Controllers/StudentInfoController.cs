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

        [HttpPost]
        public async Task<IActionResult> Post(StudentInfoDtos dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var studentInfo = await _studentInfoService.Create(dto);

            if (studentInfo != null)
                return Created("/api/StudentInfo", studentInfo);
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
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