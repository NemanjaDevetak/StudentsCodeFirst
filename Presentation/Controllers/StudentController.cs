using Application.Service.Dtos;
using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> Get(int page, int pageSize, int? courseId, string? firstName, string? lastName)
        {
            try
            {
                return Ok(await studentService.GetStudents(page, pageSize, courseId, firstName, lastName));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> ById(int id)
        {
            try
            {
                return Ok(await studentService.GetStudent(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file.", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpGet("name/{firstName}")]
        public async Task<ActionResult<GetStudentDto>> ByName(string firstName)
        {
            try
            {
                return Ok(await studentService.GetStudent(firstName));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file.", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<InsertStudentDto>> Post(InsertStudentDto insertStudentDto)
        {
            try
            {
                await studentService.AddStudent(insertStudentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@insertStudentDto} is empty.", insertStudentDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdateStudentDto>> Put(UpdateStudentDto updateStudentDto)
        {
            try
            {
                await studentService.UpdateStudent(updateStudentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@updateStudentDto} doesn't exist in database.", updateStudentDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                await studentService.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object with Id {@id} already deleted from database.", id, ex.Message);
                throw new Exception("Server error");
            }
        }
    }
}
