using Anexa.Domain.Entities;
using Anexa.Domain.Exceptions;
using Xunit;

namespace Anexa.Domain.Tests.Entities
{
    public class ModuloTests
    {
        [Fact]
        public void Deve_criar_modulo_valido()
        {
            var modulo = new Modulo(
                titulo: "Introdução ao Clean Architecture",
                ordem: 1,
                cursoId: Guid.NewGuid()
            );

            Assert.Equal("Introdução ao Clean Architecture", modulo.Titulo);
            Assert.Equal(1, modulo.Ordem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Nao_deve_criar_modulo_com_titulo_invalido(string tituloInvalido)
        {
            Assert.Throws<DomainException>(() =>
                new Modulo(
                    titulo: tituloInvalido,
                    ordem: 1,
                    cursoId: Guid.NewGuid()

                ));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Nao_deve_criar_modulo_com_ordem_invalida(int ordemInvalida)
        {
            Assert.Throws<DomainException>(() =>
                new Modulo(
                    titulo: "Módulo inválido",
                    ordem: ordemInvalida,
                    cursoId: Guid.NewGuid()
                ));
        }
    }
}