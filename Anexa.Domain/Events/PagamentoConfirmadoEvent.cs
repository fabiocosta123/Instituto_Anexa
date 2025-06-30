using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Events
{
    public class PagamentoConfirmadoEvent
    {
        public Guid PagamentoId { get; }
        public Guid AlunoId { get; }
        public Guid InstrutorId { get; }
        public string CursoTitulo { get; }

        public PagamentoConfirmadoEvent(Guid pagamentoId, Guid alunoId, Guid instrutorId, string cursoTitulo)
        {
            PagamentoId = pagamentoId;
            AlunoId = alunoId;
            InstrutorId = instrutorId;
            CursoTitulo = cursoTitulo;
        }
    }
}
