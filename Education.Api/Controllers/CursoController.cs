using Education.Application.Cursos;
using Education.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CursoDto>>> Get()
        {
            return await mediator.Send(new GetCursoQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] CreateCursoCommandRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
