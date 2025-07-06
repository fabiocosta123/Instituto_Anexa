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
           

            var senhaHash = CriptografarSenha(command.Senha); // ou usar um serviço de hash

            var usuario = new Usuario(command.Nome, cpf, email, endereco, senhaHash);

            await _usuarioRepository.Adicionar(usuario);

            return new CriarUsuarioResult(usuario.Id,
                usuario.Nome
            );

        }

        // 🔐 Método auxiliar para gerar o hash da senha
        private string CriptografarSenha(string senha)
        {
            // Exemplo com SHA256 (não recomendado para produção)
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}
