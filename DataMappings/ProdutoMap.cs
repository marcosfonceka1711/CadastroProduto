using CadastroProduto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroProduto.DataMappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(c => c.Codigo);

            builder.Property(c => c.Codigo).HasColumnName("codigo");
            builder.Property(c => c.Descricao).HasColumnName("descricao");
            builder.Property(c => c.Estoque).HasColumnName("estoque");
            builder.Property(c => c.Preco).HasColumnName("preco");

            builder.Property(c => c.Descricao).HasMaxLength(200);

            builder.HasData(new Produto
            {
                Codigo = 1,
                Descricao = "Caneta azul",
                Estoque = 7,
                Preco = 1.70
            });

            builder.HasData(new Produto
            {
                Codigo = 2,
                Descricao = "Lápis",
                Estoque = 16,
                Preco = 0.60
            });

            builder.HasData(new Produto
            {
                Codigo = 3,
                Descricao = "Régua 20cm",
                Estoque = 9,
                Preco = 3.90
            });

            builder.HasData(new Produto
            {
                Codigo = 4,
                Descricao = "Pct sulfite A4 c/ 100",
                Estoque = 23,
                Preco = 9.80
            });

            builder.HasData(new Produto
            {
                Codigo = 5,
                Descricao = "Caneta marca texto amarela",
                Estoque = 4,
                Preco = 5.30
            });

        }
    }
}