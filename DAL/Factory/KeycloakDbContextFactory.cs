using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.factory;

public class KeycloakDbContextFactory : IDesignTimeDbContextFactory<KeycloakDbContext>
{
    public KeycloakDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<KeycloakDbContext>();
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5433;Database=keycloak;Username=keycloak;Password=keycloak");

        return new KeycloakDbContext(optionsBuilder.Options);
    }
}