using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.CriarModulo
{
    public class CriarModuloCommand
    {
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Ordem { get; set; }
        public Guid CursoId { get; set; }
    }
}
