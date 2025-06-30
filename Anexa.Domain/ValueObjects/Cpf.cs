using Anexa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Anexa.Domain.ValueObjects
{
    public class Cpf
    {
        public string Numero { get; }
        protected Cpf() { }

        public Cpf(string numero) 
        {
            if (string.IsNullOrWhiteSpace(numero) || numero.Length != 11 || !long.TryParse(numero, out _))
            {
                throw new DomainException("CPF inválido. Deve conter 11 dígitos numéricos.");
            }

            numero = Limpar(numero);

            if (!ValidarCpf(numero))
            {
                throw new DomainException("CPF inválido. Verifique os dígitos verificadores.");
            }
            Numero = Formatado(numero);
        }

        private string Limpar(string cpf) => Regex.Replace(cpf ?? string.Empty, "[^0-9]", "");

        private string Formatado(string cpf) => Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");

        public override string ToString() => Numero;

        public override bool Equals(object obj)
        {
            return obj is Cpf outro && Numero == outro.Numero;
        }

        public override int GetHashCode() => Numero.GetHashCode();

        private bool ValidarCpf(string cpf)
        {
            if (cpf.Length != 11) return false;
            
            var numerosInvalidos = new[]
            {
                "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", 
                "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" 
            };

            if (numerosInvalidos.Contains(cpf)) return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
