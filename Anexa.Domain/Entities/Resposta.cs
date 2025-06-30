using Anexa.Domain.Exceptions;

namespace Anexa.Domain.Entities
{
    public class Resposta
    {
        public Guid Id { get; private set; }
        public Guid PerguntaId { get; private set; }
        public Guid AutorId { get; private set; } // Agora é 'Autor', não só 'Usuario'
        public string Texto { get; private set; }
        public DateTime DataCriacao { get; private set; }

        protected Resposta() { }

        public Resposta(Guid perguntaId, Guid autorId, string texto)
        {
            Id = Guid.NewGuid();
            PerguntaId = perguntaId;
            AutorId = autorId;
            Texto = texto;
            DataCriacao = DateTime.UtcNow;

            Validar();
        }

        private void Validar()
        {
            if (PerguntaId == Guid.Empty)
                throw new DomainException("Pergunta inválida.");

            if (AutorId == Guid.Empty)
                throw new DomainException("Autor da resposta inválido.");

            if (string.IsNullOrWhiteSpace(Texto))
                throw new DomainException("Texto da resposta é obrigatório.");
        }
    }
}