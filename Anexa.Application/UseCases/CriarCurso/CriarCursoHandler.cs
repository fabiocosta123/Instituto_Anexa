using Anexa.Application.DTOs;
using Anexa.Application.Interfaces;
using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Application.UseCases.CriarCurso
{
    public class CriarCursoHandler
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IModuloRepository _moduloRepository;

        public CriarCursoHandler(ICursoRepository cursoRepository, IUsuarioRepository usuarioRepository, IModuloRepository moduloRepository)
        {
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
            _moduloRepository = moduloRepository;
        }

        public async Task<CursoDto?> Handle(CriarCursoCommand command)
        {
            var instrutor = await _usuarioRepository.ObterPorId(command.InstrutorId);

            if (instrutor == null) return null;

            var curso = new Curso(command.Titulo, command.Descricao, command.Preco, instrutor);

            await _cursoRepository.Adicionar(curso);

            return new CursoDto
            {
                Id = curso.Id,
                Titulo = curso.Titulo,
                Descricao = curso.Descricao,
                Preco = curso.Preco,
                Ativo = curso.Ativo,
                DataCriacao = curso.DataCriacao,
                InstrutorId = instrutor.Id,
                NomeInstrutor = instrutor.Nome // Supondo que o usuário tem uma propriedade Nome
            };
        }
    }
}
