namespace Domain
{
    public class Produto
    {
        public string Nome { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
    }
}
