using Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class PagamentoUseCase : IPagamentoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly ILogger<PagamentoUseCase> _logger;

        public PagamentoUseCase(IPedidoRepository pedidoRepository, ILogger<PagamentoUseCase> logger, IPagamentoRepository pagamentoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task EfetuarMercadoPagoQRCodeAsync(Guid pedidoId)
        {
            _logger.LogInformation("Efetuando pagamento do pedido {PedidoId}", pedidoId);
            try
            {
                Pedido? pedido = await _pedidoRepository.GetById(pedidoId);

                if (pedido is null)
                {
                    _logger.LogError("Pedido {PedidoId} não encontrado", pedidoId);
                    throw new Exception($"Pedido {pedidoId} não encontrado");
                }

                if (pedido.Status != Status.Criado)
                {
                    _logger.LogError("Pedido {PedidoId} não pode ser pago", pedidoId);
                    throw new Exception($"Pedido {pedidoId} não pode ser pago");
                }

                Pagamento pagamento = pedido.GerarPagamento(MetodoPagamento.MercadoPagoQRCode);

                //Futuramente introduzir lógica de pagamento externo

                await _pagamentoRepository.Add(pagamento);
                await _pedidoRepository.UpdateStatus(pedido);

                _logger.LogInformation("Pagamento do pedido {PedidoId} efetuado com sucesso", pedidoId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao efetuar pagamento do pedido {PedidoId}", pedidoId);
                throw;
            }
        }

        // Método adicionado para simular um fake checkout
        public async Task<string> EfetuarFakeCheckoutAsync(Guid pedidoId)
        {
            _logger.LogInformation("Efetuando pagamento fake do pedido {PedidoId}", pedidoId);

            try
            {
                // Simulação de validações
                Pedido? pedido = await _pedidoRepository.GetById(pedidoId);
                if (pedido is null)
                {
                    _logger.LogError("Pedido {PedidoId} não encontrado para pagamento fake", pedidoId);
                    return "Pedido não encontrado";
                }

                if (pedido.Status != Status.Criado) // Exemplo de status a verificar
                {
                    _logger.LogError("Pedido {PedidoId} não pode ser pago (fake)", pedidoId);
                    return "Pedido não pode ser pago";
                }

                // Retorno de resultado fixo para simular sucesso
                return "Pagamento fake efetuado com sucesso para o pedido " + pedidoId.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao efetuar pagamento fake do pedido {PedidoId}", pedidoId);
                return "Erro ao efetuar pagamento fake";
            }
        }
    }
}
