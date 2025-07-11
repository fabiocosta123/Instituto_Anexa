using Anexa.Application.DTOs;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.AtualizarModulo
{
    public class AtualizarModuloHandler
    {
        private readonly IModuloRepository _moduloRepository;

        public AtualizarModuloHandler(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }

        public async Task<ModuloDto?> Handle(Guid id, AtualizarModuloCommand command)
        {
            var modulo = await _moduloRepository.ObterPorId(id);
           


            if (modulo == null) return null;

            modulo.Atualizar(command.Titulo, command.Ordem, command.Descricao);

            await _moduloRepository.SaveChangesAsync();

            return new ModuloDto
            {
                Id = modulo.Id,
                Titulo = modulo.Titulo,
                Descricao = modulo.Descricao,
                Ordem = modulo.Ordem,
                CursoId = modulo.CursoId,
                NomeCurso = modulo.Curso?.Titulo ?? "Curso não disponivel"
            };
        }
    }
}
