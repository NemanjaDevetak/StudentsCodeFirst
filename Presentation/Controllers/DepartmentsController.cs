using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            try
            {
                return Ok(await departmentService.GetDepartments(page, pageSize));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file", ex.Message);
                throw new Exception("Server error");
            }            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDepartmentDto>> ById(int id)
        {
            try
            {
                return Ok(await departmentService.GetDepartmentById(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file.", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<InsertDepartmentDto>> Post(InsertDepartmentDto insertDepartmentDto)
        {
            try
            {
                await departmentService.AddDepartment(insertDepartmentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@insertDepartmentDto} is empty.", insertDepartmentDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdateDepartmentDto>> Put(UpdateDepartmentDto updateDepartmentDto)
        {
            try
            {
                await departmentService.UpdateDepartment(updateDepartmentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@updateDepartmentDto} doesn't exist in database.", updateDepartmentDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                await departmentService.DeleteDepartment(id);
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
