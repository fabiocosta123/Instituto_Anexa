using Anexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Interfaces
{
    public interface INotificacaoRepository
    {
        void Adicionar(Notificacao notificacao);
        // se quiser pode adicionar métodos como:
        // IEnumerable<Notificacao> ObterPorUsuario(Guid usuarioId);
    }
}
