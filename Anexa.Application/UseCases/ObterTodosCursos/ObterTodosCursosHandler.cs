using Anexa.Application.DTOs;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.ObterTodosCursos
{
    public class ObterTodosCursosHandler
    {
        private readonly ICursoRepository _cursoRepository;
        
        public ObterTodosCursosHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<List<CursoDto>> Handle()
        {
            var cursos = await _cursoRepository.ObterTodos();
            return cursos.Select(c => new CursoDto
            {
                Id = c.Id,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                DataCriacao = c.DataCriacao,
                InstrutorId = c.InstrutorId,
                NomeInstrutor = c.Instrutor?.Nome ?? "Instrutor não encontrado",
            }).ToList();
        }
    }
}
