﻿using Anexa.Application.UseCases.AtualizarUsuario;
using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using Anexa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Anexa.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AnexaDbContext _context;

        public UsuarioRepository(AnexaDbContext context)
        {
            _context = context;
        }
        public async Task Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObterPorEmail(string email)
        {
            return await _context.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.Endereco == email.ToLowerInvariant());
        }

        public async Task<Usuario?> ObterPorId(Guid id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }        

        public async Task Remover(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
