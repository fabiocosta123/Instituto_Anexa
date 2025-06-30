using Anexa.Domain.Events;
using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Entities
{
    public class Pagamento
    {
        public Guid Id { get; private set; }
        public Guid AlunoId { get; private set; }
        public Guid CursoId { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataPagamento { get; private set; } 
        public bool Confirmado { get; private set; }

        protected Pagamento() { }   
        public Pagamento(Guid alunoId, Guid cursoId, decimal valor)
        {
            Id = Guid.NewGuid();
            AlunoId = alunoId;
            CursoId = cursoId;
            Valor = valor;
            DataPagamento = DateTime.Now;
            Confirmado = false;

            Validar();
        }

        private void Validar()
        {
            if (AlunoId == Guid.Empty)
                throw new DomainException("Aluno não pode ser vazio.");
            if (CursoId == Guid.Empty)
                throw new DomainException("Curso não pode ser vazio.");
            if (Valor <= 0)
                throw new DomainException("Valor deve ser maior que zero.");
            if (DataPagamento == default)
                throw new DomainException("Data de pagamento inválida.");
        }

        public void Confirmar(string cursoTitulo, Guid instrutorId)
        {
            if (Confirmado)
               throw new DomainException("Pagamento já confirmado.");
            if (string.IsNullOrWhiteSpace(cursoTitulo))
                throw new DomainException("Título do curso não pode ser vazio.");
           
            Confirmado = true;

            DomainEvents.Raise(new PagamentoConfirmadoEvent(
                pagamentoId: Id,
                alunoId: AlunoId,
                instrutorId: instrutorId,
                cursoTitulo: cursoTitulo
                ));
        }
    }
}
