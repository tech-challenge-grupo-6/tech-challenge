
using Domain;

namespace Application.UseCases;

public interface IPedidoUseCase
{
    Task<IEnumerable<Pedido>> TodosPedidos();
}
