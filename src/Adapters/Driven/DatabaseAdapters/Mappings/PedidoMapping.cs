using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAdapters;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedido");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.ClienteId).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.ValorTotal).IsRequired();
        builder.Property(x => x.MetodoPagamento).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Produtos).WithMany(x => x.Pedidos);
        builder.Property(x => x.CriadoEm).IsRequired();
        builder.Property(x => x.AtualizadoEm).IsRequired(false);
    }
}