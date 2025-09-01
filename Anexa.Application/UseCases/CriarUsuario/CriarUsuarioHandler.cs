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
                command.Endereco.Rua,
                command.Endereco.Numero,
                command.Endereco.Bairro,
                command.Endereco.Cidade,
                command.Endereco.Estado,
                command.Endereco.Cep);


            //var senhaHash = CriptografarSenha(command.Senha); // ou usar um serviço de hash
            var senhaHash = BCrypt.Net.BCrypt.HashPassword(command.Senha);


            var usuario = new Usuario(command.Nome, cpf, email, endereco, senhaHash);

            await _usuarioRepository.Adicionar(usuario);

            return new CriarUsuarioResult(usuario.Id,
                usuario.Nome
            );

        }
        //private string CriptografarSenha(string senha)
        //{
        //    return BCrypt.Net.BCrypt.HashPassword(senha);
        //}

    }
}
