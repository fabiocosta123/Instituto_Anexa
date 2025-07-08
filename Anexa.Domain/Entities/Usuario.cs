using Anexa.Domain.Exceptions;
using Anexa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public Cpf Cpf { get; private set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public string SenhaHash { get; private set; }
        public Endereco Endereco { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now;

        protected Usuario() { }

        public Usuario(string nome, Cpf cpf, Email email, Endereco endereco, string senhaHash)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Endereco = endereco;
            SenhaHash = senhaHash;
            Validar();
           
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new DomainException("O nome do usuário é obrigatório.");

            if (Cpf is null)
                throw new DomainException("O CPF do usuário é obrigatório.");

            if (Email is null)
                throw new DomainException("O email do usuário é obrigatório.");

            if (Endereco is null)
                throw new DomainException("O endereço do usuário é obrigatório.");
        }

        public void AtualizarDados(string nome, Cpf cpf, Email email, Endereco endereco)
        {

            Nome = nome;
            Cpf = cpf;
            Email = email;
            Endereco = endereco;
        }
    }
}
