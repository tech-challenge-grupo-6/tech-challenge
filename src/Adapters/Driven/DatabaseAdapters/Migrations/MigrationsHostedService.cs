using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DatabaseAdapters.Migrations
{
    public class MigrationsHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrationsHostedService(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using IServiceScope? scope = _serviceProvider.CreateScope();
            DatabaseContext? databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            await databaseContext.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
