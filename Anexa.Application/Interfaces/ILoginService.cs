using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Interfaces
{
    public interface ILoginService
    {
        Task RegistrarRequisicao(string usuario, string rota, string metodo, DateTime dataHora);
    }
}
