using Anexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Interfaces
{
    public interface IModuloRepository
    {
        Task Adicionar(Modulo modulo);
        Task SaveChangesAsync();
        Task<List<Modulo>> ObterPorCurso(Guid cursoId);
        Task<Modulo?> ObterPorId(Guid id);
        Task Remover(Modulo modulo);
    }
}
