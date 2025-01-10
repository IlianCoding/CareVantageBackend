namespace CVB.BL.Utils.UnitOfWorkPck;

public interface IUnitOfWorkKeycloak
{
    public void BeginTransaction();
    public void CommitTransaction();
    public void RollbackTransaction();
}