using Anexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<Usuario?> ObterPorEmail(string email);
        Task Adicionar(LoginRequisicao log);
    }
}
