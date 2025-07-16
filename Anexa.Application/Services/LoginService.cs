using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public async Task RegistrarRequisicao(string usuario, string rota, string metodo, DateTime dataHora)
        {
            var log = new LoginRequisicao(usuario, rota, metodo);

            await _loginRepository.Adicionar(log);
        }
    }
}
