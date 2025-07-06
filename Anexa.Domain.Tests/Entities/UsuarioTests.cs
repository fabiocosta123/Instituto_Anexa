using Anexa.Domain.Entities;
using Anexa.Domain.Exceptions;
using Anexa.Domain.Tests.Fixtures;
using Xunit;

namespace Anexa.Domain.Tests.Entities
{
    public class UsuarioTests
    {
        [Fact]
        public void Deve_criar_usuario_valido()
        {
            var usuario = new Usuario(
                nome: "Fábio",
                cpf: VoFixture.CpfValido(),
                email: VoFixture.EmailValido(),
                endereco: VoFixture.EnderecoValido(),
                senhaHash: "senha-segura"
            );

            Assert.Equal("Fábio", usuario.Nome);
            Assert.NotEqual(Guid.Empty, usuario.Id);
            Assert.NotNull(usuario.Cpf);
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.Endereco);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Nao_deve_criar_usuario_com_nome_invalido(string nomeInvalido)
        {
            Assert.Throws<DomainException>(() =>
                new Usuario(
                    nome: nomeInvalido,
                    cpf: VoFixture.CpfValido(),
                    email: VoFixture.EmailValido(),
                    endereco: VoFixture.EnderecoValido(),
                    senhaHash: "senha-segura"
                ));
        }

        [Fact]
        public void Nao_deve_criar_usuario_com_cpf_nulo()
        {
            Assert.Throws<DomainException>(() =>
                new Usuario(
                    nome: "Fábio",
                    cpf: null,
                    email: VoFixture.EmailValido(),
                    endereco: VoFixture.EnderecoValido(),
                    senhaHash: "senha-segura"
                ));
        }

        [Fact]
        public void Nao_deve_criar_usuario_com_email_nulo()
        {
            Assert.Throws<DomainException>(() =>
                new Usuario(
                    nome: "Fábio",
                    cpf: VoFixture.CpfValido(),
                    email: null,
                    endereco: VoFixture.EnderecoValido(),
                    senhaHash: "senha-segura"
                ));
        }

        [Fact]
        public void Nao_deve_criar_usuario_com_endereco_nulo()
        {
            Assert.Throws<DomainException>(() =>
                new Usuario(
                    nome: "Fábio",
                    cpf: VoFixture.CpfValido(),
                    email: VoFixture.EmailValido(),
                    endereco: null,
                    senhaHash: "senha-segura"
                ));
        }
    }
}