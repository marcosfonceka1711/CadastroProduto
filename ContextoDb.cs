using CadastroProduto.DataMappings;
using CadastroProduto.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroProduto
{
    public class ContextoDb : DbContext
    {
        public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProdutoMap());            
        }

        public DbSet<Produto> Produto { get; set; }
    }
}
