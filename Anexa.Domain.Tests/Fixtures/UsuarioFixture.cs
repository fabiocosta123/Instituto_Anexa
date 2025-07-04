using Anexa.Domain.Entities;

namespace Anexa.Domain.Tests.Fixtures
{
    public static class UsuarioFixture
    {
        public static Usuario UsuarioValido(string nome = "Fábio")
            => new Usuario(
                nome,
                VoFixture.CpfValido(),
                VoFixture.EmailValido(),
                VoFixture.EnderecoValido()
            );
    }
}