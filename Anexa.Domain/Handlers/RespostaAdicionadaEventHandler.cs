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
    public class RespostaAdicionadaEventHandler
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public RespostaAdicionadaEventHandler(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository ?? throw new ArgumentNullException(nameof(notificacaoRepository));
        }

        public void Handle(RespostaAdicionadaEvent evento)
        {
            if (evento.AutorPerguntaId == evento.AutorRespostaId) 
            return; // evita notificar a si mesmo
            
            var mensagem = $"O usuário {evento.AutorRespostaId} respondeu à sua pergunta {evento.PerguntaId}: {evento.TextoResposta}";
            _notificacaoRepository.Adicionar(new Notificacao(evento.AutorPerguntaId, mensagem));
        }
    }
}
