using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CVB.DAL.Factory;

public class CareVantageContextFactory : IDesignTimeDbContextFactory<CareVantageDbContext>
{
    public CareVantageDbContext CreateDbContext(string[] args)
    {
        var environmentName = "Development";
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        
        var careVantageConnectionString = configuration.GetConnectionString("CareVantageConnection");
        
        var optionsBuilder = new DbContextOptionsBuilder<CareVantageDbContext>();
        optionsBuilder.UseNpgsql(careVantageConnectionString);
        
        return new CareVantageDbContext(optionsBuilder.Options);
    }
}