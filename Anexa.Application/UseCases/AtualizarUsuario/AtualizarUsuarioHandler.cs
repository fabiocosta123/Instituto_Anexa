using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using Anexa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.AtualizarUsuario
{
    public class AtualizarUsuarioHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AtualizarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(AtualizarUsuarioCommand command)
        {
            var usuario = await _usuarioRepository.ObterPorId(command.Id);

            if (usuario == null) return false;

            usuario.AtualizarDados(command.Nome, new Cpf(command.Cpf), new Email(command.Email),
                new Endereco (command.Endereco.Rua, command.Endereco.Numero, command.Endereco.Bairro,
                    command.Endereco.Cidade,command.Endereco.Estado, command.Endereco.Cep
                )
            );
            return true;
        }

       
    }
}
