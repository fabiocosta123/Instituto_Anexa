using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.DTOs
{
    public class ModuloDto
    {
        public Guid Id { get; set; }    
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Ordem { get; set; }
        public Guid CursoId { get; set; }
        public string NomeCurso { get; set; } = string.Empty;
    }
}
