using Application.Service.Dtos;
using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> Get(int page, int pageSize, int? courseId, string? firstName, string? lastName)
        {
            return Ok(await studentService.GetStudents(page, pageSize, courseId, firstName, lastName));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> ById(int id)
        {
            return Ok(await studentService.GetStudent(id));
        }

        [HttpGet("name/{firstName}")]
        public async Task<ActionResult<GetStudentDto>> ByName(string firstName)
        {
            return Ok(await studentService.GetStudent(firstName));
        }

        [HttpPost]
        public async Task<ActionResult<InsertStudentDto>> Post(InsertStudentDto insertStudentDto)
        {
            await studentService.AddStudent(insertStudentDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateStudentDto>> Put(UpdateStudentDto updateStudentDto)
        {
            await studentService.UpdateStudent(updateStudentDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            await studentService.DeleteStudent(id);
            return Ok();
        }
    }
}
