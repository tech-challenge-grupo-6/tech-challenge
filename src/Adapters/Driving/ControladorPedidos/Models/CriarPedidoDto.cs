using Domain;

namespace ControladorPedidos;

public record CriarPedidoDto(Guid ClienteId, List<Guid> ProdutosIds)
{
    public static explicit operator Pedido(CriarPedidoDto dto) => new()
    {
        ClienteId = dto.ClienteId,
        Produtos = dto.ProdutosIds.Select(p => new Produto 
        { 
            Id = p
        }).ToList(),
    };
}
