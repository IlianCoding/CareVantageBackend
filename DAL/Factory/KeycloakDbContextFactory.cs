using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CVB.DAL.Factory;

public class KeycloakDbContextFactory : IDesignTimeDbContextFactory<KeycloakDbContext>
{
    public KeycloakDbContext CreateDbContext(string[] args)
    {
        var environmentName = "Development";
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        
        var keycloakConnectionString = configuration.GetConnectionString("KeycloakConnection");
        
        var optionsBuilder = new DbContextOptionsBuilder<KeycloakDbContext>();
        optionsBuilder.UseNpgsql(keycloakConnectionString);
        
        return new KeycloakDbContext(optionsBuilder.Options);
    }
}