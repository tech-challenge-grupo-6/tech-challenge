namespace Domain
{
    public class Pedido : EntityBase
    {
        public virtual Cliente Cliente { get; set; } = null!;
        public Guid ClienteId { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; } = null!;
        public double ValorTotal { get; set; }
        public string MetodoPagamento { get; set; } = null!;
    }
}
