using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Map
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProdutoId);
            builder.HasOne(x => x.Produto);
      

        }
    }
}