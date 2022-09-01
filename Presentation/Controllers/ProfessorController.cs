using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProfessorDto>>> Get(int page, int pageSize, int? courseId, string? firstName, string? lastName)
        {
            try
            {
                return Ok(await professorService.GetProfessors(page, pageSize, courseId, firstName, lastName));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProfessorDto>> ById(int id)
        {
            try
            {
                return Ok(await professorService.GetProfessor(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file.", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpGet("name/{firstName}")]
        public async Task<ActionResult<GetProfessorDto>> ByName(string firstName)
        {
            try
            {
                return Ok(await professorService.GetProfessor(firstName));
            }
            catch (Exception ex)
            {
                Log.Fatal("Could not find the requested file.", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<InsertProfessorDto>> Post(InsertProfessorDto insertProfessorDto)
        {
            try
            {
                await professorService.AddProfessor(insertProfessorDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@insertProfessorDto} is empty.", insertProfessorDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdateProfessorDto>> Put(UpdateProfessorDto updateProfessorDto)
        {
            try
            {
                await professorService.UpdateProfessor(updateProfessorDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@updateProfessorDto} doesn't exist in database.", updateProfessorDto, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                await professorService.DeleteProfessor(id);
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
