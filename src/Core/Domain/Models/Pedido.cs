namespace Domain
{
    public class Pedido
    {
        public string Id { get; set; }
        public Cliente Cliente { get; set; }
        public Status Status { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        public double ValorTotal { get; set; }
        public string MetodoPagamento { get; set; }
    }
}
