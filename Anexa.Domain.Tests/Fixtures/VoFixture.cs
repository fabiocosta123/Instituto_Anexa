using Anexa.Domain.ValueObjects;

namespace Anexa.Domain.Tests.Fixtures
{
    public static class VoFixture
    {
        public static Cpf CpfValido()
            => new("11144477735");

        public static Email EmailValido()
            => new("fabio@exemplo.com");

        public static Dinheiro Valor(decimal valor = 100.00m)
            => new(valor);

        public static Endereco EnderecoValido()
            => new(
                rua: "Av. Brasil",
                numero: "100",
                bairro: "Centro",
                cidade: "Registro",
                estado: "SP",
                cep: "11900000"
            );
    }
}