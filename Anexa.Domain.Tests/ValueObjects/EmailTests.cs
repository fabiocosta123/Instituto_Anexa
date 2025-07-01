using Anexa.Domain.Exceptions;
using Anexa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Tests.ValueObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("usuario@email.com")]
        [InlineData("NOME.SOBRENOME@dominio.org")]
        [InlineData("com.mascara@dominio.com.br")]

        public void Deve_Criar_Email_Valido(string endereco)
        {
            // Arrange & Act
            var email = new Email(endereco);
            // Assert
            Assert.Equal(endereco.Trim().ToLowerInvariant(), email.Endereco);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("sem-arroba.com")]
        [InlineData("com espaço@dominio.com")]
        [InlineData("@semprefixo.com")]
        [InlineData("usuario@")]
        [InlineData("usuario@@dominio.com")]

        public void Deve_Lancar_Excecao_Para_Email_Invalido(string endereco)
        {
            // Arrange & Act & Assert
            Assert.Throws<DomainException>(() => new Email(endereco));
        }

        [Fact]
        public void Emails_iguais_devem_ser_iguais()
        {
            // Arrange
            var email1 = new Email(" TESTE@EXEMPLO.com ");
            var email2 = new Email("teste@exemplo.com");

            // Assert
            Assert.Equal(email1, email2);
            Assert.True(email1.Equals(email2));
            Assert.Equal(email1.GetHashCode(), email2.GetHashCode());
        }

        [Fact]
        public void ToString_deve_retornar_endereco_formatado()
        {
            var email = new Email("CONTATO@Empresa.com");
            Assert.Equal("contato@empresa.com", email.ToString());
        }

    }
}
