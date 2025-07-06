using Anexa.Application.DTOs;
using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.Queries
{
    public class ObterTodosUsuariosHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterTodosUsuariosHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public async Task<List<UsuarioDto>> Handle(ObterTodosUsuariosQuery query)
        {
            var usuarios = await _usuarioRepository.ObterTodos();

            return usuarios.Select(usuario => new UsuarioDto
            {
                Id = usuario.Id,
                Cpf = usuario.Cpf.ToString(),
                Nome = usuario.Nome,
                Email = usuario.Email,
                Endereco = usuario.Endereco,
                DataCadastro = usuario.DataCadastro
            }).ToList();
        }
    }
}
