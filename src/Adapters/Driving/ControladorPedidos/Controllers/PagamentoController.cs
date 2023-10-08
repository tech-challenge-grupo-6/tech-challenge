using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    private readonly IPagamentoUseCase _pagamentoUseCase;
    private readonly ILogger<PagamentoController> _logger;

    public PagamentoController(IPagamentoUseCase pagamentoUseCase, ILogger<PagamentoController> logger)
    {
        _pagamentoUseCase = pagamentoUseCase;
        _logger = logger;
    }

    [HttpPut("pagar/{pedidoId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(Guid pedidoId)
    {
        try
        {
            _logger.LogInformation("Efetuando pagamento do pedido {PedidoId}", pedidoId);
            await _pagamentoUseCase.EfetuarMercadoPagoQRCodeAsync(pedidoId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao efetuar pagamento do pedido {PedidoId}", pedidoId);
            return BadRequest($"Erro ao efetuar pagamento do pedido {pedidoId}");
        }
    }
}
