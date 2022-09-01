using Application.Service;
using Application.Service.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int page, int pageSize, string? courseName) 
        {
            return await ExecuteMethod(() => courseService.GetCourses(page, pageSize, courseName));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ById(int id)
        {
            return await ExecuteMethod(() => courseService.GetCourseById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertCourseDto insertCourseDto)
        {
            return await ExecuteMethod(() => courseService.AddCourse(insertCourseDto));
        }
        
        [HttpPost("Professor")]
        public async Task<ActionResult> Post(CourseProfessorDto courseProfessorDto)
        {
            try
            {
                await courseService.AddProfessor(courseProfessorDto.CourseDto, courseProfessorDto.ProfessorDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@courseProfessorDto} doesn't exist in database.", courseProfessorDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPost("Student")]
        public async Task<ActionResult> Post(StudentCourseDto studentCourseDto)
        {
            try
            {
                await courseService.AddStudent(studentCourseDto.CourseDto, studentCourseDto.StudentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@studentCourseDto} doesn't exist in database.", studentCourseDto, ex.Message);
                throw new Exception("Server error");
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<UpdateCourseDto>> Put(UpdateCourseDto updateCourseDto) 
        {
            try
            {
                await courseService.UpdateCourse(updateCourseDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@updateCourseDto} doesn't exist in database.", updateCourseDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                await courseService.DeleteCourse(id);
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
