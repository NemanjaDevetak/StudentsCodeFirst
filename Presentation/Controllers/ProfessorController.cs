using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await professorService.GetProfessors(page, pageSize, courseId, firstName, lastName));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProfessorDto>> ById(int id)
        {
            return Ok(await professorService.GetProfessor(id));
        }

        [HttpGet("name/{firstName}")]
        public async Task<ActionResult<GetProfessorDto>> ByName(string firstName)
        {
            return Ok(await professorService.GetProfessor(firstName));
        }

        [HttpPost]
        public async Task<ActionResult<InsertProfessorDto>> Post(InsertProfessorDto insertProfessorDto)
        {
            await professorService.AddProfessor(insertProfessorDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateProfessorDto>> Put(UpdateProfessorDto updateProfessorDto)
        {
            await professorService.UpdateProfessor(updateProfessorDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            await professorService.DeleteProfessor(id);
            return Ok();
        }
    }
}
