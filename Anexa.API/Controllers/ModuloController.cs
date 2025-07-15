using Anexa.Application.DTOs;
using Anexa.Domain.Interfaces;
using Anexa.Application.UseCases.AtualizarModulo;
using Anexa.Application.UseCases.CriarModulo;
using Anexa.Application.UseCases.RemoverModulo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Anexa.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ModuloController : ControllerBase
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly ICursoRepository _cursoRepository;

        public ModuloController(IModuloRepository moduloRepository, ICursoRepository cursoRepository)
        {
            _moduloRepository = moduloRepository;
            _cursoRepository = cursoRepository;
        }

        [Authorize(Roles = "Professor")]
        [HttpPost]
        public async Task<ActionResult<ModuloDto>> Criar([FromBody] CriarModuloCommand command)
        {
            var handler = new CriarModuloHandler(_moduloRepository, _cursoRepository);
            var moduloCriado = await handler.Handle(command);

            return CreatedAtAction(nameof(ObterPorCurso), new { cursoId = command.CursoId },
                moduloCriado);
        }

        [HttpGet("/api/Cursos/{cursoId}/Modulos")]
        public async Task<ActionResult<List<ModuloDto>>> ObterPorCurso(Guid cursoId)
        {
            var modulos = await _moduloRepository.ObterPorCurso(cursoId);
            var dtos = modulos.Select(m => new ModuloDto
            {
                Id = m.Id,
                Titulo = m.Titulo,
                Descricao = m.Descricao,
                Ordem = m.Ordem,
                CursoId = m.CursoId,
                NomeCurso = m.Curso?.Titulo ?? "Curso não disponível"
            }).ToList();

            return Ok(dtos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModuloDto>> Atualizar(Guid id, [FromBody] AtualizarModuloCommand command)
        {
            var handler = new AtualizarModuloHandler(_moduloRepository);

            var atualizado = await handler.Handle(id, command);

            if (atualizado == null)
                return NotFound("Modulo não encontrado");

            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var handler = new RemoverModuloHandler(_moduloRepository);

            var sucesso = await handler.Handle(id);

            if (!sucesso)
                return NotFound("Módulo não encontrado");

            return NoContent();
        }
    }
}
