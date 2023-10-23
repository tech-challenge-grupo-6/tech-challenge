using Domain;

namespace ControladorPedidos;

public record ProdutoIds(Guid Id, double Preco);
public record CriarPedidoDto(Guid ClienteId, Guid PagamentoId, double ValorTotal, List<ProdutoIds> Produtos)
{

    public static explicit operator Pedido(CriarPedidoDto dto) => new()
    {
        ClienteId = dto.ClienteId,
        PagamentoId = dto.PagamentoId,
        ValorTotal = dto.ValorTotal,
        Produtos = dto.Produtos.Select(p => new Produto { Id = p.Id, Preco = p.Preco }).ToList(),
    };
}
