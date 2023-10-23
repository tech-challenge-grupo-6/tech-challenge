using Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases;

public class PedidoUseCase : IPedidoUseCase
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly ILogger<PedidoUseCase> _logger;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IClienteRepository _clienteRepository;

    public PedidoUseCase(IPedidoRepository pedidoRepository, ILogger<PedidoUseCase> logger, 
    IProdutoRepository produtoRepository, IClienteRepository clienteRepository)
    {
        _pedidoRepository = pedidoRepository;
        _logger = logger;
        _produtoRepository = produtoRepository;
        _clienteRepository = clienteRepository;
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

    public async Task MontarPedido(Pedido pedido)
    {
        _logger.LogInformation("Criando pedido");

        var valorTotal = 0.0;
        foreach (var p in pedido.Produtos)
        {
            var produto = await _produtoRepository.GetById(p.Id) ?? throw new NotFoundException("Produto não encontrado");
            valorTotal += produto.Preco;
        }

        pedido.ValorTotal = valorTotal;
        pedido.Produtos = null;
        try
        {
            await _pedidoRepository.Add(pedido);    
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar pedido");
            throw;
        }    
    }
}
