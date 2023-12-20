using ControladorPedidos.App.Entities;

namespace ControladorPedidos.App.Contracts;

public interface IPagamentoUseCase
{
    Task EfetuarMercadoPagoQRCodeAsync(Guid pedidoId);
    Task<Pagamento> ConsultarPagamentoPeloPedido(Guid pedidoId);
}
