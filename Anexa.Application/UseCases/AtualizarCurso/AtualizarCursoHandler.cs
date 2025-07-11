using Anexa.Application.DTOs;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.AtualizarCurso
{
    public class AtualizarCursoHandler
    {
        private readonly ICursoRepository _cursoRepository;

        public AtualizarCursoHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<CursoDto> Handle(Guid id, AtualizarCursoCommand command)
        {
            var curso = await _cursoRepository.ObterPorId(id);
            if (curso == null) return null;

            curso.Atualizar(command.Titulo, command.Descricao, command.Preco);

            await _cursoRepository.Adicionar(curso);
            return new CursoDto
            {
                Id = curso.Id,
                Titulo = curso.Titulo,
                Descricao = curso.Descricao,
                Preco = curso.Preco
            };
        }
    }
}
