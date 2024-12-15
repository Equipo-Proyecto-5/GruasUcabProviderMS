using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Infrastructure.Database.Configurations
{
    public class GruasConfiguration
    {
        public void Configure(EntityTypeBuilder<Grua> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Tipo).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Marca).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Modelo).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Año).IsRequired().HasMaxLength(10);
            builder.Property(s => s.Placa).IsRequired().HasMaxLength(10);
            builder.Property(s => s.Color).IsRequired().HasMaxLength(10);
            builder.Property(s => s.Estatus).IsRequired().HasMaxLength(15);
            builder.Property(s => s.Localizacion).HasMaxLength(30);
            builder.Property(s => s.Longitud).HasMaxLength(30);
            builder.Property(s => s.Latitud).HasMaxLength(30);
            builder.Property(s => s.Hora).HasMaxLength(30);

            builder
            .HasOne(grua => grua.Proveedor) // Una grúa tiene un proveedor
            .WithMany(proveedor => proveedor.Gruas) // Un proveedor tiene muchas grúas
            .HasForeignKey(grua => grua.ProveedorId) // Clave foránea en Grua
            .OnDelete(DeleteBehavior.Cascade); // Elimina las grúas si se elimina el proveedor
        }

    }
}
