using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.AtualizarModulo
{
    public class AtualizarModuloCommand
    {
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Ordem { get; set; }
    }
}
