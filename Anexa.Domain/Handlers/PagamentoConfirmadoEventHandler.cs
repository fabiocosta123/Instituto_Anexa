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
    public class PagamentoConfirmadoEventHandler
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public PagamentoConfirmadoEventHandler(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        public void Handle(PagamentoConfirmadoEvent evento)
        {
            var msgAluno = $"Seu pagamento foi confirmado! Você já pode acessar o curso: {evento.CursoTitulo}";
            var msgInstrutor = $"Um novo aluno se matriculou no curso: {evento.CursoTitulo}";

            _notificacaoRepository.Adicionar(new Notificacao(evento.AlunoId, msgAluno));
            _notificacaoRepository.Adicionar(new Notificacao(evento.InstrutorId, msgInstrutor));
        }
    }
}
