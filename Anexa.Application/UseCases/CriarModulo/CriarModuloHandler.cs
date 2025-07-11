using Anexa.Application.DTOs;
using Anexa.Application.Interfaces;
using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.CriarModulo
{
    public class CriarModuloHandler
    {

        private readonly IModuloRepository _moduloRepository;
        private readonly ICursoRepository _cursoRepository;

        public CriarModuloHandler(IModuloRepository moduloRepository, ICursoRepository cursoRepository)
        {
            _moduloRepository = moduloRepository;
            _cursoRepository = cursoRepository;
        }

        public async Task<ModuloDto> Handle(CriarModuloCommand command)
        {
            var modulo = new Modulo(command.Titulo, command.Ordem, command.CursoId, command.Descricao);

            await _moduloRepository.Adicionar(modulo);
            await _moduloRepository.SaveChangesAsync();

            var curso = await _cursoRepository.ObterPorId(command.CursoId);


            return new ModuloDto
            {
                Id = modulo.Id,
                Titulo = modulo.Titulo,
                Descricao = modulo.Descricao,
                Ordem = modulo.Ordem,
                CursoId = modulo.CursoId,
                NomeCurso = modulo.Curso?.Titulo ?? "Curso não disponível"
            };
        }
    }

}
