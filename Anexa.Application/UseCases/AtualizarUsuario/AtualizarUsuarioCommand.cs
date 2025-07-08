using Anexa.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.AtualizarUsuario
{
    public class AtualizarUsuarioCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
