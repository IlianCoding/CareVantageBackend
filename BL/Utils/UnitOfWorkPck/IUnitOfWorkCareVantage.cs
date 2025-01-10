namespace CVB.BL.Utils.UnitOfWorkPck;

public interface IUnitOfWorkCareVantage
{
     public void BeginTransaction();
     public void CommitTransaction();
     public void RollbackTransaction();
}