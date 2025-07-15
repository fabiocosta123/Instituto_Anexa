using Anexa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Infrastructure.Context
{
    public class AnexaDbContext : DbContext
    {
        public AnexaDbContext(DbContextOptions<AnexaDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnexaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public AnexaDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AnexaDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AnexaDbContext(optionsBuilder.Options);
        }

    }
}
