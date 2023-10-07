using Domain;

namespace Application.UseCases;

public class PedidoUseCase : IPedidoUseCase
{

    private readonly IPedidoRepository _pedidoRepository;
    public PedidoUseCase(IPedidoRepository pedidoRepository){
        _pedidoRepository = pedidoRepository;
    }

    public async Task<IEnumerable<Pedido>> TodosPedidos()
    {
        var result = await _pedidoRepository.GetAll();
        return result;
    }
}
