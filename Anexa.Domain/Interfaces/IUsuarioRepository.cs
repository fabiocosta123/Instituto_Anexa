using Anexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Adicionar(Usuario usuario);
        Task<List<Usuario>> ObterTodos();
        Task<Usuario?> ObterPorId(Guid id);
        Task<Usuario?> ObterPorEmail(string email);
        Task Remover(Usuario usuario);

    }
}
