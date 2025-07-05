using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.CriarUsuario
{
    public class CriarUsuarioResult
    {
        public Guid Id { get; }
        public string Nome { get; }

        public CriarUsuarioResult(Guid id, string nome)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

    }
}
