using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DatabaseAdapters.Migrations;

public class MigrationsHostedService(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope? scope = serviceProvider.CreateScope();
        DatabaseContext? databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        await databaseContext.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
