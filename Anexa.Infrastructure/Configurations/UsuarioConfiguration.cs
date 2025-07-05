using Anexa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);

            builder.OwnsOne(u => u.Cpf, cpf =>
            {
                cpf.Property(c => c.Numero)
                .HasColumnName("Cpf")
                .IsRequired()
                .HasMaxLength(11);
            });

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Endereco)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(150);
            });

            builder.OwnsOne(u => u.Endereco, endereco =>
            {
                endereco.Property( e => e.Rua).IsRequired().HasMaxLength(100);
                endereco.Property(e => e.Numero).IsRequired().HasMaxLength(10);
                endereco.Property(e => e.Bairro).IsRequired().HasMaxLength(50);
                endereco.Property(e => e.Cidade).IsRequired().HasMaxLength(50);
                endereco.Property(e => e.Estado).IsRequired().HasMaxLength(2);
                endereco.Property(e => e.Cep).IsRequired().HasMaxLength(8);
            } );
        }
    }
}
