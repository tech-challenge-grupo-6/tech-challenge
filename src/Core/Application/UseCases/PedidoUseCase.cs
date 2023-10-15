using Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases;

public class PedidoUseCase : IPedidoUseCase
{

    private readonly IPedidoRepository _pedidoRepository;
    private readonly ILogger<PedidoUseCase> _logger;
    public PedidoUseCase(IPedidoRepository pedidoRepository, ILogger<PedidoUseCase> logger){
        _pedidoRepository = pedidoRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Pedido>> TodosPedidos()
    {
        _logger.LogInformation("Buscando todos os pedidos");

        try
        {
            var pedidos = await _pedidoRepository.GetAll();
            return pedidos.Any() ? pedidos : throw new NotFoundException("Pedidos não encontrados");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar todos os pedidos.");
            throw;
        }
    }
}
