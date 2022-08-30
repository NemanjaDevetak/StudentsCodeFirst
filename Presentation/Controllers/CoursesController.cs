using Application.Service;
using Application.Service.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCourseDto>>> Get(int page, int pageSize, string? courseName) 
        {
            return Ok(await courseService.GetCourses(page, pageSize, courseName));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCourseDto>> ById(int id)
        {
            return Ok(await courseService.GetCourseById(id));
        }

        [HttpPost]
        public async Task<ActionResult<InsertCourseDto>> Post(InsertCourseDto insertCourseDto)
        {
            await courseService.AddCourse(insertCourseDto);
            return Ok();
        }
        
        [HttpPost("Professor")]
        public async Task<ActionResult> Post(CourseProfessorDto courseProfessorDto)
        {
            await courseService.AddProfessor(courseProfessorDto.CourseDto, courseProfessorDto.ProfessorDto);
            return Ok();
        }

        [HttpPost("Student")]
        public async Task<ActionResult> Post(StudentCourseDto studentCourseDto)
        {
            await courseService.AddStudent(studentCourseDto.CourseDto, studentCourseDto.StudentDto);
            return Ok();
        }
        
        [HttpPut]
        public async Task<ActionResult<UpdateCourseDto>> Put(UpdateCourseDto updateCourseDto) 
        {
            await courseService.UpdateCourse(updateCourseDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id) 
        {
            await courseService.DeleteCourse(id);
            return Ok();
        }
    }
}
