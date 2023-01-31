using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Map
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(x => x.VendaId);
            
            builder.HasMany(i => i.Items)
                   .WithOne(v => v.Venda);

            
            builder.Property(x => x.VendedorId);
            builder.HasOne(x => x.Vendedor);

        }
    }
}