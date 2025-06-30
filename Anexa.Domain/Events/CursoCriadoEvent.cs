using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Events
{
    public class CursoCriadoEvent
    {
        public Guid CursoId { get; }
        public string Titulo { get; }
        public Guid InstrutorId { get; }

        public CursoCriadoEvent(Guid cursoId, string titulo, Guid instrutorId)
        {
            CursoId = cursoId;
            Titulo = titulo;
            InstrutorId = instrutorId;
        }
    }
}
