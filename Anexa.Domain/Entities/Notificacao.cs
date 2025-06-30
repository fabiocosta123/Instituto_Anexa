using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Entities
{
    public class Notificacao
    {
        public Guid Id { get; private set; }
        public Guid UsuarioId { get; private set; }
        public string Mensagem { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Lida { get; private set; }

        protected Notificacao() { }

        public Notificacao(Guid usuarioId, string mensagem)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Mensagem = mensagem;
            DataCriacao = DateTime.UtcNow;
            Lida = false;

            Validar();            
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Mensagem))
                throw new DomainException("A mensagem não pode ser vazia.");
        }

        public void MarcarComoLida() => Lida = true;


    }
}
