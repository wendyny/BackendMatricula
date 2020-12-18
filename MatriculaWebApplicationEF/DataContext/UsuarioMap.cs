using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DataContext
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "dbo");
            builder.HasKey(q => q.UsuarioId);
            builder.Property(e => e.UsuarioId).IsRequired();
            builder.Property(e => e.PasswordUsuario).HasColumnType("varchar(50)")
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.isActive);

        }
    }
}
