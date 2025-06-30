using Anexa.Domain.Events;
using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Entities
{
    public class Curso
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; } = true;

        public Guid InstrutorId { get; private set; }
        public Usuario Instrutor { get; private set; }

        private readonly List<Modulo> _modulos = new();

        protected Curso() { }

        public Curso(string titulo, string descricao, decimal preco, Usuario instrutor)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            Ativo = true;
            DataCriacao = DateTime.Now;
            Instrutor = instrutor ?? throw new DomainException("Instrutor inválido.");
            InstrutorId = instrutor.Id;

            Validar();

            //Disparar eventos de domínio, se necessário
            DomainEvents.Raise(new CursoCriadoEvent(Id, Titulo, InstrutorId));
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                throw new CannotUnloadAppDomainException("Título é Obrigatório.");
            }

            if (Preco < 0)
            {
                throw new CannotUnloadAppDomainException("Preço inválido.");
            }
        }

        public void AdicionarModulo(Modulo modulo)
        {
            if (modulo == null)
            {
                throw new DomainException("Módulo inválido.");                
            }
            _modulos.Add(modulo);
        }

        public void Desativar()
        {
            Ativo = false;            
        }
    }
}
