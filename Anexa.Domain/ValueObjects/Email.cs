using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Anexa.Domain.ValueObjects
{
    public class Email
    {
        public string Endereco { get; }
        protected Email() { }

        public Email(string endereco) 
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new DomainException("O endereço de e-mail não pode ser vazio.");

            endereco = endereco.Trim().ToLowerInvariant();

            if (!EmailRegex.IsMatch(endereco))
                throw new DomainException("Formato de e-mail é inválido.");
           
            Endereco = endereco;
        }

        private static readonly Regex EmailRegex = new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        public override string ToString() => Endereco;

        public override bool Equals(object obj)
        {
            return obj is Email other && Endereco == other.Endereco;
        }

        public override int GetHashCode() => Endereco.GetHashCode();
    }
}
