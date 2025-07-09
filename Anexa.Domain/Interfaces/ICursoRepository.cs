using Anexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task Adicionar(Curso curso);
        Task<List<Curso>> ObterTodos();
        Task<Curso?> ObterPorId(Guid id);
        Task Remover(Curso curso);
    }
}
