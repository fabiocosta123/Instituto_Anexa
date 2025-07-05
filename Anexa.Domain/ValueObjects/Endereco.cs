using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.ValueObjects
{
    public class Endereco
    {
        public string Rua { get; }
        public string Numero { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public string Cep { get; }

        protected Endereco() { }

        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
        {
            if (string.IsNullOrWhiteSpace(rua)) throw new DomainException("A rua é obrigatória.");
            if (string.IsNullOrWhiteSpace(numero)) throw new DomainException("O número é obrigatório.");
            if (string.IsNullOrWhiteSpace(bairro)) throw new DomainException("O bairro é obrigatório.");
            if (string.IsNullOrWhiteSpace(cidade)) throw new DomainException("A cidade é obrigatória.");
            if (string.IsNullOrWhiteSpace(estado)) throw new DomainException("O estado é obrigatório.");
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8) throw new DomainException("O CEP é obrigatório.");

            Rua = rua.Trim();
            Numero = numero.Trim();
            Bairro = bairro.Trim();
            Cidade = cidade.Trim();
            Estado = estado.Trim().ToUpperInvariant();
            Cep = cep.Trim().Replace("-", "").Replace(" ", ""); // Normaliza o CEP removendo espaços e traços
        }

        public override string ToString()
        {
            return $"{Rua}, {Numero} - {Bairro}, {Cidade} - {Estado}, {FormatarCep(Cep)}";
        }

        private string FormatarCep(string cep)
        {
            return Convert.ToUInt64(cep).ToString(@"00000-000");
        }

        public override bool Equals(object obj)
        {
            return obj is Endereco other &&
                   Rua == other.Rua &&
                   Numero == other.Numero &&
                   Bairro == other.Bairro &&
                   Cidade == other.Cidade &&
                   Estado == other.Estado &&
                   Cep == other.Cep;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rua, Numero, Bairro, Cidade, Estado, Cep);
        }
    }
}
