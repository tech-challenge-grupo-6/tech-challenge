using Domain;

namespace DatabaseAdapters.Repositories;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly DatabaseContext _dbContext;

    public PagamentoRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Pagamento pagamento)
    {
        _dbContext.Pagamentos.Add(pagamento);
        await _dbContext.SaveChangesAsync();
    }
}
