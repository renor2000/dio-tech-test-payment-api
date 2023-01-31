using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Map;

namespace TrilhaApiDesafio.Context
{
    public class VendasContext : DbContext
    {
        public VendasContext(DbContextOptions<VendasContext> options) : base(options)
        {}

        public DbSet<Venda>    Vendas { get; set; }
    }

    public class VendedorContext : DbContext
    {
        public VendedorContext(DbContextOptions<VendedorContext> options) : base(options)
        {}
        public DbSet<Vendedor> Vendedors { get; set; }
    }

    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {}
        public DbSet<Item> Itens { get; set; }
    }
    
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {}
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.ApplyConfiguration(new VendedorMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            base.OnModelCreating(modelBuilder);
       }
    }



}