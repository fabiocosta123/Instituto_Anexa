using Anexa.Domain.Exceptions;
using Anexa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Tests.ValueObjects
{
    public class CpfTests
    {
        [Theory]
        [InlineData("11144477735", "111.444.777-35")]
        [InlineData("111.444.777-35", "111.444.777-35")]

        public void Deve_Criar_Cpf_Valido(string entrada, string esperadoFormatado)
        {
            // Act
            var cpf = new Cpf(entrada);          

            // Assert
            Assert.NotNull(cpf);
            Assert.Equal(esperadoFormatado, cpf.Numero);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData("00000000000")]
        [InlineData("11111111111")]

        public void Deve_Lancar_Exception_Para_Cpf_Invalido(string entradaInvalida)
        {
            // Act & Assert
            Assert.Throws<DomainException>(() => new Cpf(entradaInvalida));
        }

        [Fact]
        public void Cpfs_iguais_devem_ser_iguais()
        {
            // Arrange
            var cpf1 = new Cpf("11144477735");
            var cpf2 = new Cpf("111.444.777-35");

            // Act & Assert
            Assert.Equal(cpf1, cpf2);
            Assert.True(cpf1.Equals(cpf2));
            Assert.Equal(cpf1.GetHashCode(), cpf2.GetHashCode());
        }

        [Fact]
        public void ToString_deve_retornar_cpf_formatado()
        {
            var cpf = new Cpf("12345678909");
            Assert.Equal("123.456.789-09", cpf.ToString());
        }
       
        
    }
}
