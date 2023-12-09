namespace ControladorPedidos.App.Entities.Repositories;

public interface IPagamentoRepository
{
    Task Add(Pagamento pagamento);
}
