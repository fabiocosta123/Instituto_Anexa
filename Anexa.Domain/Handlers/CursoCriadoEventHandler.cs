using Anexa.Domain.Entities;
using Anexa.Domain.Events;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Handlers
{
    public class CursoCriadoEventHandler
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public CursoCriadoEventHandler(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        public void Handle(CursoCriadoEvent evento)
        {
            var mensagem = $"Curso {evento.Titulo} criado com sucesso!";
            var notificacao = new Notificacao(evento.InstrutorId, mensagem);

            _notificacaoRepository.Adicionar(notificacao);
        }
    }
}
