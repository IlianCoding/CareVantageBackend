using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CVB.DAL.Initializer;

public class DatabaseInitializer(
    CareVantageDbContext careVantageDbContext,
    KeycloakDbContext keycloakDbContext,
    ILogger<DatabaseInitializer> logger)
    : IDatabaseInitializer
{
    public async Task InitializeAsync()
    {
        await CheckDatabaseConnectionsAsync();
        await EnsureDatabasesCreatedAsync();
        await ApplyMigrationsAsync();
    }

    private async Task CheckDatabaseConnectionsAsync()
    {
        try
        {
            logger.LogInformation("Testing database connections...");
            
            await careVantageDbContext.Database.CanConnectAsync();
            logger.LogInformation("Successfully connected to CareVantage database");
            
            await keycloakDbContext.Database.CanConnectAsync();
            logger.LogInformation("Successfully connected to Keycloak database");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to connect to database");
            throw new Exception("Database connection failed. Please check your connection strings and ensure databases are running.", e);
        }
    }

    private async Task EnsureDatabasesCreatedAsync()
    {
        try
        {
            logger.LogInformation("Ensuring databases exist...");
            
            if (!await careVantageDbContext.Database.CanConnectAsync())
            {
                await careVantageDbContext.Database.EnsureCreatedAsync();
                logger.LogInformation("Created CareVantage database");
            }
            
            if (!await keycloakDbContext.Database.CanConnectAsync())
            {
                await keycloakDbContext.Database.EnsureCreatedAsync();
                logger.LogInformation("Created Keycloak database");
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to ensure databases exist");
            throw new Exception("Failed to create databases", e);
        }
    }

    private async Task ApplyMigrationsAsync()
    {
        try
        {
            logger.LogInformation("Checking and applying pending migrations...");

            var careVantagePendingMigrations = (await careVantageDbContext.Database.GetPendingMigrationsAsync()).ToList();
            var keycloakPendingMigrations = (await keycloakDbContext.Database.GetPendingMigrationsAsync()).ToList();

            if (careVantagePendingMigrations.Any())
            {
                logger.LogInformation($"Applying {careVantagePendingMigrations.Count} pending migrations to CareVantage database...");
                await careVantageDbContext.Database.MigrateAsync();
            }

            if (keycloakPendingMigrations.Any())
            {
                logger.LogInformation($"Applying {keycloakPendingMigrations.Count} pending migrations to Keycloak database...");
                await keycloakDbContext.Database.MigrateAsync();
            }

            logger.LogInformation("All migrations have been applied successfully");
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to apply migrations");
            throw new Exception("Failed to apply database migrations", e);
        }
    }
}