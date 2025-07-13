using EduTrack.Core.Application.DTOs;
using EduTrack.Core.Application.Interfaces;
using EduTrack.Core.Application.Services;
using EduTrack.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Core.API.Controllers
{
    public class StudentsController : ControllerBase
    {
      private readonly IStudentService _studentService;
        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound();           
                return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] StudentCreateDto student)
        {
            await _studentService.AddAsync(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentCreateDto student)
        {
            if (id != student.Id) return BadRequest();
            await _studentService.UpdateAsync(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok();
        }
    }
}
   