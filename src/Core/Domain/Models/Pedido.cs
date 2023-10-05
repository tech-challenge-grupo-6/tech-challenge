namespace Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public int ClienteId { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; } = null!;
        public double ValorTotal { get; set; }
        public string MetodoPagamento { get; set; } = null!;
    }
}
