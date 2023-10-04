using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAdapters;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Descricao).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Preco).IsRequired();
        builder.Property(x => x.Imagem).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CategoriaId).IsRequired();
        builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.CategoriaId);
        builder.HasMany(x => x.Pedidos).WithMany(x => x.Produtos);
    }
}
