using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class PagamentoController(IPagamentoUseCase pagamentoUseCase, ILogger<PagamentoController> logger) : ControllerBase
{
    /// <summary>
    /// Realiza pagamento do pedido
    /// </summary>
    /// <param name="pedidoId">Id do pedido</param>
    /// <response code="204">Pagamento do pedido realizado com sucesso.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    [HttpPut("pagar/{pedidoId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(Guid pedidoId)
    {
        try
        {
            logger.LogInformation("Efetuando pagamento do pedido {PedidoId}", pedidoId);
            await pagamentoUseCase.EfetuarMercadoPagoQRCodeAsync(pedidoId);
            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao efetuar pagamento do pedido {PedidoId}", pedidoId);
            return BadRequest($"Erro ao efetuar pagamento do pedido {pedidoId}");
        }
    }
}
