using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.RemoverModulo
{
    public class RemoverModuloHandler
    {
        private readonly IModuloRepository _moduloRepository;

        public RemoverModuloHandler(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }

        public async Task<bool> Handle(Guid id)
        {
            var modulos = await _moduloRepository.ObterPorId(id);

            var modulo = await _moduloRepository.ObterPorId(id);

            if (modulo == null) return false;

            await _moduloRepository.Remover(modulo);
            return true;

        }
    }
}
