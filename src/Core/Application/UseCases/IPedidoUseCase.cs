
using Domain;

namespace Application.UseCases;

public interface IPedidoUseCase
{
    Task<IEnumerable<Pedido?>> TodosPedidos();
    Task AlterarStatusPedido(Guid id, Status novoStatus);
}
