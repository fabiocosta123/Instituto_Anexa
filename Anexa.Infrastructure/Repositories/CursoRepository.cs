using Anexa.Domain.Entities;
using Anexa.Domain.Interfaces;
using Anexa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Anexa.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AnexaDbContext _context;

        public CursoRepository(AnexaDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Curso>> ObterTodos()
        {
            return await _context.Cursos
                .Include(c => c.Instrutor) // se quiser o nome do instrutor no DTO
                .ToListAsync();
        }

        public async Task<Curso?> ObterPorId(Guid id)
        {
            return await _context.Cursos
                .Include(c => c.Instrutor)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Remover(Curso curso)
        {
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
        }
    }
}