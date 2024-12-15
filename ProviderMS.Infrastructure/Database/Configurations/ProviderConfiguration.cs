using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMS.Infrastructure.Database.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.Property(s=> s.Id).IsRequired();    
            builder.Property(S=> S.DenominacionComercial).IsRequired().HasMaxLength(30);
            builder.Property(s => s.RazonSocial).IsRequired().HasMaxLength(30);
            builder.Property(s=>s.DireccionFisica).IsRequired().HasMaxLength(100);
            builder.Property(s=>s.TipoDocumentoIdentidad).IsRequired().HasMaxLength(1);
            builder.Property(s => s.NumeroDocumentoIdentidad).IsRequired().HasMaxLength(10);
            builder.Property(s=>s.Estatus).IsRequired().HasMaxLength(15);

            builder
           .HasMany(proveedor => proveedor.Gruas) // Un proveedor tiene muchas grúas
           .WithOne(grua => grua.Proveedor) // Una grúa tiene un proveedor
           .HasForeignKey(grua => grua.ProveedorId) // Clave foránea en Grua
           .OnDelete(DeleteBehavior.Cascade); // Elimina las grúas si se elimina el proveedor
        }
    }
 }

