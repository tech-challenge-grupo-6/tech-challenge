namespace ControladorPedidos.App.Contracts;

public interface IPagamentoUseCase
{
    Task EfetuarMercadoPagoQRCodeAsync(Guid pedidoId);
}
