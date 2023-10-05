namespace Domain
{
    public class CategoriaProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public virtual ICollection<Produto> Produtos { get; set; } = null!;
    }
}
