using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.DTOs
{
    public class EnderecoDto
    {
        public string Rua { get; set; } 
        public string Numero { get; set; } 
        public string Bairro { get; set; } 
        public string Cidade { get; set; }
        public string Estado { get; set; } 
        public string Cep { get; set; } 
    }
}
