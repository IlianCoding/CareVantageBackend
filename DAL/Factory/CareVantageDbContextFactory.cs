using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.factory;

public class CareVantageDbContextFactory : IDesignTimeDbContextFactory<CareVantageDbContext>
{
    public CareVantageDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CareVantageDbContext>();
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=carevantage;Username=postgres;Password=postgres");

        return new CareVantageDbContext(optionsBuilder.Options);
    }
}