using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Entities
{
    public class Modulo
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public int Ordem { get; private set; }
        public Guid CursoId { get; private set; }
        public Curso Curso { get; private set; }

        protected Modulo() { }

        public Modulo(string titulo, int ordem, Guid cursoId, string? descricao = null)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Ordem = ordem;
            CursoId = cursoId;
            Descricao = descricao;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                throw new DomainException("O título do módulo é obrigatório.");
            }

            if (Ordem <= 0)
            {
                throw new DomainException("A ordem do módulo deve ser maior que zero.");
            }
        }

        public void Atualizar(string titulo, int ordem, string? descricao = null)
        {
            Titulo = titulo;
            Ordem = ordem;
            Descricao = descricao;
            Validar();
        }
    }
}
