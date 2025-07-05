using Anexa.Domain.Events;
using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Entities
{
    public class Pergunta
    {
        public Guid Id { get; private set; }
        public Guid AlunoId { get; private set; }
        public Guid AutorId { get; private set; }
        public Guid CursoId { get; private set; }
        public string Texto { get; private set; }
        public DateTime DataCriacao { get; private set; }

        private readonly List<Resposta> _respostas = new List<Resposta>();

        public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();

        protected Pergunta() { }

        public Pergunta(Guid alunoId, Guid autorId, Guid cursoId, string texto)
        {
            Id = Guid.NewGuid();
            AlunoId = alunoId;
            AutorId = autorId;
            CursoId = cursoId;
            Texto = texto;
            DataCriacao = DateTime.UtcNow;

            Validar();
        }

        private void Validar()
        {
            if (AlunoId == Guid.Empty)
                throw new DomainException("Aluno não pode ser vazio.");
            if (AutorId == Guid.Empty)
                throw new DomainException("Autor não pode ser vazio.");
            if (CursoId == Guid.Empty)
                throw new DomainException("Curso não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(Texto))
                throw new DomainException("Texto não pode ser vazio.");
        }

        public void AdicionarResposta(Resposta resposta)
        {
            if (resposta == null)
                throw new DomainException("Resposta não pode ser nula.");

            _respostas.Add(resposta);

            DomainEvents.Raise(new RespostaAdicionadaEvent(
                perguntaId: this.Id,
                autorPerguntaId: this.AutorId,
                autorRespostaId: resposta.AutorId,
                textoResposta: resposta.Texto
            ));

        }
    }
}
