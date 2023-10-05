namespace Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public virtual CategoriaProduto Categoria { get; set; } = null!;
        public int CategoriaId { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; } = null!;
        public string Imagem { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; } = null!;
    }
}
