using Application.Service;
using Application.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace UniversityMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var objStudentList = await studentService.GetStudents(1, 10, null, null, null);
            return View();
        }

        public async Task<JsonResult> Get()
        {
            var studentList = await studentService.GetStudents(1, 20, null, null, null);
            return Json(new { data = studentList.Result });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertStudentDto insertStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(insertStudentDto);
            }

            await studentService.AddStudent(insertStudentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
           var student = await studentService.GetStudent(id);

            return View(new UpdateStudentDto { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName});
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentDto updateStudentDto) 
        {
            await studentService.UpdateStudent(updateStudentDto);
            return RedirectToAction("Index");
        }
    }
}
