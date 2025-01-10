using CVB.DAL.Context;

namespace CVB.BL.Utils.UnitOfWorkPck;

public class UnitOfWorkKeycloak(KeycloakDbContext context) : IUnitOfWorkKeycloak
{
    public void BeginTransaction()
    {
        context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        context.SaveChanges();
        context.Database.CommitTransaction();
    }
    
    public void RollbackTransaction()
    {
        context.Database.RollbackTransaction();
    }
}