using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.Queries
{
    public class ObterUsuarioPorIdQuery
    {
        public Guid Id { get; }

        public ObterUsuarioPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
