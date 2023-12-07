using Domain;

namespace DatabaseAdapters.Repositories;

public class PagamentoRepository(DatabaseContext dbContext) : IPagamentoRepository
{
    public async Task Add(Pagamento pagamento)
    {
        dbContext.Pagamentos.Add(pagamento);
        await dbContext.SaveChangesAsync();
    }
}
