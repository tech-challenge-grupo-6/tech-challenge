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

    /// <summary>
    /// Realiza pagamento do pedido
    /// </summary>
    /// <param name="pedidoId">Id do pedido</param>
    /// <response code="204">Pagamento do pedido realizado com sucesso.</response>
    /// <response code="400">Erro ao fazer a Request.</response>

    /*    [HttpPut("pagar/{pedidoId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    */

    [HttpPut("fakecheckout/{pedidoId}")]
    public async Task<IActionResult> FakeCheckout(Guid pedidoId)
    {
        try
        {
            _logger.LogInformation("Iniciando fake checkout do pedido {PedidoId}", pedidoId);
            string resultado = await _pagamentoUseCase.EfetuarFakeCheckoutAsync(pedidoId);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante o fake checkout do pedido {PedidoId}", pedidoId);
            return BadRequest($"Erro durante o fake checkout do pedido {pedidoId}");
        }
    }
}
