using ComercioOnline.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar2");

            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(10);

            throw new NotImplementedException();
        }
    }
}
