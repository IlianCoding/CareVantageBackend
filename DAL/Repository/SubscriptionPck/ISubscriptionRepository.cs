using CVB.BL.Domain.SubscriptionPck;

namespace CVB.DAL.Repository.SubscriptionPck;

public interface ISubscriptionRepository
{
    public Subscription GetSubscription(Guid subscriptionId);
    public void CreateSubscription(Subscription subscription);
    public void UpdateSubscription(Subscription subscription);
    public void DeleteSubscriptionById(Guid subscriptionId);
    public IEnumerable<Subscription> GetAllSubscriptions();
}