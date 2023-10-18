using Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases;

public class PedidoUseCase : IPedidoUseCase
{

    private readonly IPedidoRepository _pedidoRepository;
    private readonly ILogger<PedidoUseCase> _logger;
    public PedidoUseCase(IPedidoRepository pedidoRepository, ILogger<PedidoUseCase> logger)
    {
        _pedidoRepository = pedidoRepository;
        _logger = logger;
    }

    public async Task AlterarStatusPedido(Guid id, Status novoStatus)
    {
        try
        {
            _logger.LogInformation("Alterando status do pedido {id} para {status}", id, novoStatus.ToString());

            var pedido = await _pedidoRepository.GetById(id) ?? throw new NotFoundException("Pedido não encontrado");
            Status statusAtual = pedido.Status;
            if (novoStatus < statusAtual)
                throw new BusinessException("Não é possível alterar o status do pedido para um status inferior ao atual");
            if (novoStatus == statusAtual)
                throw new BusinessException("Não é possível alterar o status do pedido para o mesmo status atual");
            if (novoStatus > statusAtual + 1)
                throw new BusinessException("Não é possível alterar o status do pedido para um status superior ao atual + 1");

            pedido.Status = novoStatus;

            await _pedidoRepository.UpdateStatus(pedido);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao alterar status do pedido {id} para {status}", id, novoStatus.ToString());
            throw;
        }
    }

    public async Task<IEnumerable<Pedido?>> TodosPedidos()
    {
        var result = await _pedidoRepository.GetAll();
        return result;
    }
}
