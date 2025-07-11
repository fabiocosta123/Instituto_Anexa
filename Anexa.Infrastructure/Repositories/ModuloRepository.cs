using Anexa.Domain.Interfaces;
using Anexa.Domain.Entities;
using Anexa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Infrastructure.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly AnexaDbContext _context;
        public ModuloRepository(AnexaDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Modulo modulo) => await _context.Modulos.AddAsync(modulo);

        public async Task<List<Modulo>> ObterPorCurso(Guid cursoId) => await _context.Modulos.Where(m => m.CursoId == cursoId).Include(m => m.Curso).ToListAsync();

        public async Task<Modulo?> ObterPorId(Guid id)
        {
            return await _context.Modulos
                .Include(m => m.Curso) // se quiser trazer o curso junto
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Remover(Modulo modulo)
        {
            _context.Modulos.Remove(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}
