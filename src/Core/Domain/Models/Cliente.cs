namespace Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Email { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; } = null!;
    }
}
