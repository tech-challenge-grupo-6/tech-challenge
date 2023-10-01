using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DatabaseAdapters;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@Directory.GetCurrentDirectory() + "/../../Driving/ControladorPedidos/appsettings.json")
            .Build();
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        DbContextOptionsBuilder<DatabaseContext>? optionsBuilder = new();
        optionsBuilder.UseMySQL(connectionString!);
        return new DatabaseContext(optionsBuilder.Options);
    }
}
