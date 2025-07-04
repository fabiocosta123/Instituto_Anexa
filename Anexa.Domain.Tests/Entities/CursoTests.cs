using Anexa.Domain.Entities;
using Anexa.Domain.Exceptions;
using Anexa.Domain.Tests.Fixtures;
using Xunit;

namespace Anexa.Domain.Tests.Entities
{
    public class CursoTests
    {
        [Fact]
        public void Deve_criar_curso_valido()
        {
            var instrutor = UsuarioFixture.UsuarioValido();

            var curso = new Curso(
                titulo: "Curso de Arquitetura",
                descricao: "Aprenda Clean Architecture na prática",
                preco: 499.90m,
                instrutor: instrutor
            );

            Assert.Equal("Curso de Arquitetura", curso.Titulo);
            Assert.Equal("Aprenda Clean Architecture na prática", curso.Descricao);
            Assert.Equal(499.90m, curso.Preco);
            Assert.Equal(instrutor.Id, curso.InstrutorId);
            Assert.True(curso.Ativo);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Nao_deve_criar_curso_com_titulo_invalido(string tituloInvalido)
        {
            var instrutor = UsuarioFixture.UsuarioValido();

            Assert.Throws<CannotUnloadAppDomainException>(() =>
                new Curso(
                    titulo: tituloInvalido,
                    descricao: "Descrição",
                    preco: 100,
                    instrutor: instrutor
                ));
        }

        [Fact]
        public void Nao_deve_criar_curso_com_instrutor_nulo()
        {
            Assert.Throws<DomainException>(() =>
                new Curso(
                    titulo: "Curso",
                    descricao: "Descrição",
                    preco: 100,
                    instrutor: null
                ));
        }

        [Fact]
        public void Nao_deve_criar_curso_com_preco_negativo()
        {
            var instrutor = UsuarioFixture.UsuarioValido();

            Assert.Throws<CannotUnloadAppDomainException>(() =>
                new Curso(
                    titulo: "Curso",
                    descricao: "Descrição",
                    preco: -10,
                    instrutor: instrutor
                ));
        }
    }
}