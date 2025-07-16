using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Entities
{
    public class LoginRequisicao
    {
        public Guid Id { get; private set; }
        public string Usuario { get; private set; }
        public string Rota { get; private set; }
        public string Metodo { get; private set; }
        public DateTime DataHora { get; private set; }

        public LoginRequisicao(string usuario, string rota, string metodo)
        {
            Id = Guid.NewGuid();
            Usuario = usuario;
            Rota = rota;
            Metodo = metodo;
            DataHora = DateTime.UtcNow;
        }
    }
}
