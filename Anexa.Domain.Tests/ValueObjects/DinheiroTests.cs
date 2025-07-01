using Anexa.Domain.Exceptions;
using Anexa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Tests.ValueObjects
{
    public class DinheiroTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(49.90)]
        [InlineData(100.00)]
        [InlineData(199.999)] // Deve arredondar para 200.00

        public void Deve_criar_valor_monetario_valido(decimal valor)
        {
            // Act
            var dinheiro = new Dinheiro(valor);

            // Assert
            Assert.Equal(decimal.Round(valor, 2), dinheiro.Valor);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-99.99)]

        public void Nao_deve_aceitar_valor_negativo(decimal valorInvalido)
        {
            Assert.Throws<DomainException>(() => new Dinheiro(valorInvalido));
        }

        [Fact]
        public void Valores_iguais_devem_ser_iguais()
        {
            // Arrange
            var dinheiro1 = new Dinheiro(25.50m);
            var dinheiro2 = new Dinheiro(25.5000m);

            // Act & Assert
            Assert.Equal(dinheiro1, dinheiro2);
            Assert.True(dinheiro1.Equals(dinheiro2));
            Assert.Equal(dinheiro1.GetHashCode(), dinheiro2.GetHashCode());
        }

        [Fact]
        public void Somar_deve_retornar_valor_corrigido()
        {
            var dinheiro1 = new Dinheiro(100.00m);
            var dinheiro2 = new Dinheiro(49.99m);

            var resultado = dinheiro1.Somar(dinheiro2);

            Assert.Equal(149.99m, resultado.Valor);
        }

        [Fact]
        public void Subtrair_deve_funcionar_com_valor_menor()
        {
            var dinheiro1 = new Dinheiro(200.00m);
            var dinheiro2 = new Dinheiro(50.00m);

            var resultado = dinheiro1.Subtrair(dinheiro2);

            Assert.Equal(150.00m, resultado.Valor);
        }

        [Fact]
        public void Nao_deve_subtrair_valor_maior_do_que_o_atual()
        {
            var dinheiro1 = new Dinheiro(50.00m);
            var dinheiro2 = new Dinheiro(100.00m);

            Assert.Throws<DomainException>(() => dinheiro1.Subtrair(dinheiro2));
        }

        [Fact]
        public void ToString_deve_retornar_valor_formatado_com_cultura_pt_BR()
        {
            var dinheiro = new Dinheiro(1234.56m);
            var texto = dinheiro.ToString();
            
            Assert.Contains("R$", texto);
            Assert.Contains("1.234,56", texto);
            
        }
    }
}
