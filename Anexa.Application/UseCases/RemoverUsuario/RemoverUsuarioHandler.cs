using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.RemoverUsuario
{
    public class RemoverUsuarioHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public RemoverUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<bool> Handle(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);
            if (usuario == null) return false;
            
            await _usuarioRepository.Remover(usuario);
            return true;
        }
    }
}
