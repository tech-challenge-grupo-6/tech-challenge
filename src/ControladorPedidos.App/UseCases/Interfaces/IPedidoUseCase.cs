using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Shared;

namespace ControladorPedidos.App.UseCases.Interfaces;

public interface IPedidoUseCase
{
    Task<IEnumerable<Pedido?>> TodosPedidos();
    Task AlterarStatusPedido(Guid id, Status novoStatus);
    Task MontarPedido(Pedido pedido);
}
