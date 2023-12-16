using ControladorPedidos.App.Contracts;

namespace ControladorPedidos.App.UseCases.DependencyInjection;

public static class UseCasesDependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaProdutoUseCase, CategoriaProdutoUseCase>();
        services.AddScoped<IPagamentoUseCase, PagamentoUseCase>();
        services.AddScoped<IPedidoUseCase, PedidoUseCase>();
        services.AddScoped<IProdutoUseCase, ProdutoUseCase>();
        services.AddScoped<IClienteUseCase, ClienteUseCase>();

        return services;
    }
}
