using Anexa.Application.DTOs;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.ObterCursoPorId
{
    public class ObterCursoPorIdHandler
    {
        private readonly ICursoRepository _cursoRepository;

        public ObterCursoPorIdHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<CursoDto> Handle(Guid id)
        {
            var curso = await _cursoRepository.ObterPorId(id);
            if (curso == null) return null;

            return new CursoDto
            {
                Id = curso.Id,
                Titulo = curso.Titulo,
                Descricao = curso.Descricao,
                Preco = curso.Preco,
                Ativo = curso.Ativo,
                DataCriacao = curso.DataCriacao,
                InstrutorId = curso.InstrutorId,
                NomeInstrutor = curso.Instrutor?.Nome ?? "Instrutor não encontrado"
            };
        }
    }
}
