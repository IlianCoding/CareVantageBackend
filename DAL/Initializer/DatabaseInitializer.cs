using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CVB.DAL.Initializer;

public class DatabaseInitializer : IDatabaseInitializer
{
    private readonly CareVantageDbContext _careVantageDbContext;
    private readonly KeycloakDbContext _keycloakDbContext;
    private readonly ILogger<DatabaseInitializer> _logger;
    
    public DatabaseInitializer(CareVantageDbContext careVantageDbContext, KeycloakDbContext keycloakDbContext, ILogger<DatabaseInitializer> logger)
    {
        _careVantageDbContext = careVantageDbContext;
        _keycloakDbContext = keycloakDbContext;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        await CheckDatabaseConnectionsAsync();
        if (!await CheckIfDatabaseHasTablesAsync())
        {
            await InitializeEmptyDatabases();
        }
    }

    private async Task CheckDatabaseConnectionsAsync()
    {
        try
        {
            _logger.LogInformation("Testing database connections...");
            
            await _careVantageDbContext.Database.CanConnectAsync();
            _logger.LogInformation("Successfully connected to CareVantage database");
            
            await _keycloakDbContext.Database.CanConnectAsync();
            _logger.LogInformation("Successfully connected to Keycloak database");

        } catch (Exception e)
        {
            _logger.LogError(e, "Failed to connect to database");
            throw new Exception("Database connection failed. Please check your connection strings and ensure databases are running.", e);
        }
    }

    private async Task<bool> CheckIfDatabaseHasTablesAsync()
    {
        try
        {
            var careVantageTables = (await _careVantageDbContext.Database
                .SqlQuery<int>($"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'public'")
                .ToListAsync()).FirstOrDefault() > 0;
            
            var keycloakTables = (await _keycloakDbContext.Database
                .SqlQuery<int>($"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'public'")
                .ToListAsync()).FirstOrDefault() > 0;
            
            _logger.LogInformation($"Database status - CareVantage: {careVantageTables}, Keycloak: {keycloakTables}");
            return careVantageTables && keycloakTables;
        } catch (Exception e)
        {
            _logger.LogError(e, "Failed to check if database has tables");
            throw new Exception("Failed to check if database has tables", e);
        }
    }
    
    private async Task InitializeEmptyDatabases()
    {
        try
        {
            _logger.LogInformation("Initializing empty databases...");

            await _careVantageDbContext.Database.MigrateAsync();
            await _keycloakDbContext.Database.MigrateAsync();

            _logger.LogInformation("Database initialization completed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to initialize empty databases");
            throw;
        }
    }
}