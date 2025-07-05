using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using Anexa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.CriarUsuario
{
    public class CriarUsuarioHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CriarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public async Task<CriarUsuarioResult> Handler(CriarUsuarioCommand command)
        {
            var email = new Email(command.Email);
            var cpf = new Cpf(command.Cpf);            
            var endereco = new Endereco(
                command.Rua,
                command.Numero,
                command.Bairro,
                command.Cidade,
                command.Estado,
                command.Cep);
            var usuario = new Usuario(command.Nome, cpf, email, endereco);

            await _usuarioRepository.Adicionar(usuario);

            return new CriarUsuarioResult(usuario.Id,
                usuario.Nome
                );

        }
    }
}
