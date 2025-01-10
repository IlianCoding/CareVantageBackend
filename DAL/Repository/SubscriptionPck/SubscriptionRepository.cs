using CVB.BL.Domain.SubscriptionPck;
using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Repository.SubscriptionPck;

public class SubscriptionRepository(CareVantageDbContext context) : ISubscriptionRepository
{
    public Subscription GetSubscription(Guid subscriptionId)
    {
        return context.Subscriptions
            .Include(p => p.Period)
            .Include(c => c.Pricing)
            .SingleOrDefault();
    }

    public void CreateSubscription(Subscription subscription)
    {
        context.Subscriptions.Add(subscription);
    }

    public void UpdateSubscription(Subscription subscription)
    {
        context.Subscriptions.Update(subscription);
    }

    public void DeleteSubscriptionById(Guid subscriptionId)
    {
        Subscription subscription = GetSubscription(subscriptionId);
        context.Subscriptions.Remove(subscription);
    }

    public IEnumerable<Subscription> GetAllSubscriptions()
    {
        return context.Subscriptions
            .Include(p => p.Period)
            .Include(c => c.Pricing)
            .ToList();
    }
}