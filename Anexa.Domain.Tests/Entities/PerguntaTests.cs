using Anexa.Domain.Entities;
using Anexa.Domain.Exceptions;
using Xunit;

namespace Anexa.Domain.Tests.Entities
{
    public class PerguntaTests
    {
        [Fact]
        public void Deve_criar_pergunta_valida()
        {
            var pergunta = new Pergunta(
                alunoId: Guid.NewGuid(),
                autorId: Guid.NewGuid(),
                cursoId: Guid.NewGuid(),
                texto: "Qual a diferença entre Clean Architecture e DDD?"
            );

            Assert.NotEqual(Guid.Empty, pergunta.Id);
            Assert.NotEqual(Guid.Empty, pergunta.AlunoId);
            Assert.NotEqual(Guid.Empty, pergunta.AutorId);
            Assert.NotEqual(Guid.Empty, pergunta.CursoId);
            Assert.Equal("Qual a diferença entre Clean Architecture e DDD?", pergunta.Texto);
            Assert.True(pergunta.DataCriacao <= DateTime.UtcNow);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Nao_deve_criar_pergunta_com_texto_invalido(string textoInvalido)
        {
            Assert.Throws<DomainException>(() =>
                new Pergunta(
                    alunoId: Guid.NewGuid(),
                    autorId: Guid.NewGuid(),
                    cursoId: Guid.NewGuid(),
                    texto: textoInvalido
                ));
        }

        [Fact]
        public void Nao_deve_criar_pergunta_com_alunoId_vazio()
        {
            Assert.Throws<DomainException>(() =>
                new Pergunta(
                    alunoId: Guid.Empty,
                    autorId: Guid.NewGuid(),
                    cursoId: Guid.NewGuid(),
                    texto: "Pergunta válida"
                ));
        }

        [Fact]
        public void Nao_deve_criar_pergunta_com_autorId_vazio()
        {
            Assert.Throws<DomainException>(() =>
                new Pergunta(
                    alunoId: Guid.NewGuid(),
                    autorId: Guid.Empty,
                    cursoId: Guid.NewGuid(),
                    texto: "Pergunta válida"
                ));
        }

        [Fact]
        public void Nao_deve_criar_pergunta_com_cursoId_vazio()
        {
            Assert.Throws<DomainException>(() =>
                new Pergunta(
                    alunoId: Guid.NewGuid(),
                    autorId: Guid.NewGuid(),
                    cursoId: Guid.Empty,
                    texto: "Pergunta válida"
                ));
        }

        [Fact]
        public void Deve_adicionar_resposta_valida()
        {
            var pergunta = new Pergunta(
                alunoId: Guid.NewGuid(),
                autorId: Guid.NewGuid(),
                cursoId: Guid.NewGuid(),
                texto: "O que é injeção de dependência?"
            );

            var resposta = new Resposta(
                autorId: Guid.NewGuid(),
                perguntaId: pergunta.Id,
                texto: "É um padrão que permite desacoplar dependências entre classes."
            );

            pergunta.AdicionarResposta(resposta);

            Assert.Single(pergunta.Respostas);
            Assert.Equal(resposta.Texto, pergunta.Respostas.First().Texto);
        }

        [Fact]
        public void Nao_deve_adicionar_resposta_nula()
        {
            var pergunta = new Pergunta(
                alunoId: Guid.NewGuid(),
                autorId: Guid.NewGuid(),
                cursoId: Guid.NewGuid(),
                texto: "O que é SOLID?"
            );

            Assert.Throws<DomainException>(() =>
                pergunta.AdicionarResposta(null));
        }
    }
}