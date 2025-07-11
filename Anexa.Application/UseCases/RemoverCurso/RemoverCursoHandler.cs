using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.RemoverCurso
{
    public class RemoverCursoHandler
    {
        private readonly ICursoRepository _cursoRepository;

        public RemoverCursoHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<bool> Handle(Guid id)
        {
            var curso = await _cursoRepository.ObterPorId(id);

            if (curso == null) return false;

            await _cursoRepository.Remover(curso);
            return true;
        }
    }
}
