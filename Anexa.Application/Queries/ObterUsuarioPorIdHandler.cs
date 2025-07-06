using Anexa.Application.DTOs;
using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using Anexa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.Queries
{
    public class ObterUsuarioPorIdHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterUsuarioPorIdHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> Handle(ObterUsuarioPorIdQuery query)
        {
            var usuario = await _usuarioRepository.ObterPorId(query.Id);

            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Cpf = usuario.Cpf.ToString(),
                Nome = usuario.Nome,
                Email = usuario.Email,
                Endereco = usuario.Endereco,
                DataCadastro = usuario.DataCadastro,
            };
        }
    }
}
