using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Repositories;
using ControladorPedidos.App.Infrastructure.DataBase;

namespace ControladorPedidos.App.Gateways;

public class PagamentoRepository(DatabaseContext dbContext) : IPagamentoRepository
{
    public async Task Add(Pagamento pagamento)
    {
        dbContext.Pagamentos.Add(pagamento);
        await dbContext.SaveChangesAsync();
    }
}
