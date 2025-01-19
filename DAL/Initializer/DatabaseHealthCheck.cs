using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CVB.DAL.Initializer;

public class DatabaseHealthCheck(
    CareVantageDbContext careVantageDbContext,
    KeycloakDbContext keycloakDbContext,
    ILogger<DatabaseHealthCheck> logger) : IDatabaseHealthCheck
{
    public async Task CheckDatabasesAsync()
    {
        try
        {
            await careVantageDbContext.Database.CanConnectAsync();
            await keycloakDbContext.Database.CanConnectAsync();
            logger.LogInformation("Successfully connected to all databases");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to connect to databases");
            throw;
        }
    }
}