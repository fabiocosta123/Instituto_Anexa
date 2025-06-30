using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.ValueObjects
{
    public class Dinheiro
    {
        public decimal Valor { get; }
        protected Dinheiro() { }

        public Dinheiro(decimal valor)
        {
            if (valor < 0)
                throw new DomainException("O valor não pode ser negativo.");
            Valor = decimal.Round(valor, 2); // Limita a duas casas decimais
        }

        public Dinheiro Somar(Dinheiro outro)
        {
            if (outro is null)
                throw new DomainException("Não é possível somar um valor nulo.");
            return new Dinheiro(this.Valor + outro.Valor);
        }

        public Dinheiro Subtrair(Dinheiro outro)
        {
            if (outro is null)
                throw new DomainException("Não é possível subtrair um valor nulo.");

            if (this.Valor < outro.Valor)
                throw new DomainException("Não é possível subtrair um valor maior do que o atual.");

            return new Dinheiro(this.Valor - outro.Valor);
        }

        public override string ToString() => Valor.ToString("C", new CultureInfo("pt-BR")); // Ex: R$ 49,90

        public override bool Equals(object obj) => obj is Dinheiro outro && Valor == outro.Valor;

        public override int GetHashCode() => Valor.GetHashCode();
    }
}
