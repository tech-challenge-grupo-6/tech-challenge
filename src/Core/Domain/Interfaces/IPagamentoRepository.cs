namespace Domain;

public interface IPagamentoRepository
{
    Task Add(Pagamento pagamento);
}
