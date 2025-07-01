using Anexa.Domain.Exceptions;
using Anexa.Domain.ValueObjects;
using Xunit;

namespace Anexa.Domain.Tests.ValueObjects
{
    public class EnderecoTests
    {
        [Fact]
        public void Deve_criar_endereco_valido()
        {
            var endereco = new Endereco(
                rua: "Av. Paulista",
                numero: "1000",
                bairro: "Bela Vista",
                cidade: "São Paulo",
                estado: "SP",
                cep: "01311000"
            );

            Assert.Equal("Av. Paulista", endereco.Rua);
            Assert.Equal("1000", endereco.Numero);
            Assert.Equal("Bela Vista", endereco.Bairro);
            Assert.Equal("São Paulo", endereco.Cidade);
            Assert.Equal("SP", endereco.Estado);
            Assert.Equal("01311000", endereco.Cep);
        }

        [Theory]
        [InlineData("", "1", "Bairro", "Cidade", "SP", "01311000")]
        [InlineData("Rua", "", "Bairro", "Cidade", "SP", "01311000")]
        [InlineData("Rua", "10", "", "Cidade", "SP", "01311000")]
        [InlineData("Rua", "10", "Bairro", "", "SP", "01311000")]
        [InlineData("Rua", "10", "Bairro", "Cidade", "", "01311000")]
        [InlineData("Rua", "10", "Bairro", "Cidade", "SP", "")]
        [InlineData("Rua", "10", "Bairro", "Cidade", "SP", "123")] // CEP inválido
        public void Deve_lancar_excecao_para_endereco_invalido(string rua, string numero, string bairro, string cidade, string estado, string cep)
        {
            Assert.Throws<DomainException>(() => new Endereco(rua, numero, bairro, cidade, estado, cep));
        }

        [Fact]
        public void Enderecos_iguais_devem_ser_iguais()
        {
            var e1 = new Endereco("Rua X", "10", "Centro", "Registro", "SP", "11900000");
            var e2 = new Endereco("Rua X", "10", "Centro", "Registro", "SP", "11900000");

            Assert.Equal(e1, e2);
            Assert.True(e1.Equals(e2));
            Assert.Equal(e1.GetHashCode(), e2.GetHashCode());
        }

        [Fact]
        public void ToString_deve_retornar_endereco_formatado()
        {
            var endereco = new Endereco("Rua das Flores", "55", "Centro", "Registro", "SP", "11900000");

            var texto = endereco.ToString();

            Assert.Equal("Rua das Flores, 55 - Centro, Registro - SP, 11900-000", texto);
        }
    }
}