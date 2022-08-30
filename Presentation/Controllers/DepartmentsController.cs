using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> Get(int page, int pageSize) 
        {
            return Ok(await departmentService.GetDepartments(page, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDepartmentDto>> ById(int id)
        {
            return Ok(await departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        public async Task<ActionResult<InsertDepartmentDto>> Post(InsertDepartmentDto insertDepartmentDto)
        {
            await departmentService.AddDepartment(insertDepartmentDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateDepartmentDto>> Put(UpdateDepartmentDto updateDepartmentDto)
        {
            await departmentService.UpdateDepartment(updateDepartmentDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            await departmentService.DeleteDepartment(id);
            return Ok();
        }
    }
}
