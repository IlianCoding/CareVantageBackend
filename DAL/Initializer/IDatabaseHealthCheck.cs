namespace CVB.DAL.Initializer;

public interface IDatabaseHealthCheck
{
    public Task CheckDatabasesAsync();
}