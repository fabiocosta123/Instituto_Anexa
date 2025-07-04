using Anexa.Domain.Entities;
using Anexa.Domain.Exceptions;
using Xunit;

namespace Anexa.Domain.Tests.Entities
{
    public class RespostaTests
    {
        [Fact]
        public void Deve_criar_resposta_valida()
        {
            var resposta = new Resposta(
                perguntaId: Guid.NewGuid(),
                autorId: Guid.NewGuid(),
                texto: "Clean Architecture ajuda a manter o código desacoplado."
            );

            Assert.NotEqual(Guid.Empty, resposta.Id);
            Assert.NotEqual(Guid.Empty, resposta.PerguntaId);
            Assert.NotEqual(Guid.Empty, resposta.AutorId);
            Assert.Equal("Clean Architecture ajuda a manter o código desacoplado.", resposta.Texto);
            Assert.True(resposta.DataCriacao <= DateTime.UtcNow);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Nao_deve_criar_resposta_com_texto_invalido(string textoInvalido)
        {
            Assert.Throws<DomainException>(() =>
                new Resposta(
                    perguntaId: Guid.NewGuid(),
                    autorId: Guid.NewGuid(),
                    texto: textoInvalido
                ));
        }

        [Fact]
        public void Nao_deve_criar_resposta_com_autorId_vazio()
        {
            Assert.Throws<DomainException>(() =>
                new Resposta(
                    perguntaId: Guid.NewGuid(),
                    autorId: Guid.Empty,
                    texto: "Texto válido"
                ));
        }

        [Fact]
        public void Nao_deve_criar_resposta_com_perguntaId_vazio()
        {
            Assert.Throws<DomainException>(() =>
                new Resposta(
                    perguntaId: Guid.Empty,
                    autorId: Guid.NewGuid(),
                    texto: "Texto válido"
                ));
        }
    }
}