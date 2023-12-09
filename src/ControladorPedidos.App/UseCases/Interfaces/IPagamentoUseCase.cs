namespace ControladorPedidos.App.UseCases.Interfaces;

public interface IPagamentoUseCase
{
    Task EfetuarMercadoPagoQRCodeAsync(Guid pedidoId);
}
