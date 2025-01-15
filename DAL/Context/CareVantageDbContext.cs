using CVB.BL.Domain.AppointmentPck;
using CVB.BL.Domain.PaymentPck;
using CVB.BL.Domain.PaymentPck.BillingInvoice;
using CVB.BL.Domain.ReviewPck;
using CVB.BL.Domain.ServicePck;
using CVB.BL.Domain.SubscriptionPck;
using CVB.BL.Domain.UsagePck;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Context;

public class CareVantageDbContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentDetails> AppointmentDetails { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServicePricing> ServicePricings { get; set; }
    public DbSet<ServiceFeature> ServiceFeatures { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<SubscriptionPeriod> SubscriptionPeriods { get; set; }
    public DbSet<SubscriptionPricing> SubscriptionPricings { get; set; }
    public DbSet<UsageRecord> UsageRecords { get; set; }
    public DbSet<UsageMetrics> UsageMetrics { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentDetails> PaymentDetails { get; set; }
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewDetails> ReviewDetails { get; set; }
    
    public CareVantageDbContext(DbContextOptions<CareVantageDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Details)
                .WithOne(p => p.Appointment)
                .HasForeignKey<AppointmentDetails>(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Services");
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Pricing)
                .WithOne(p => p.Service)
                .HasForeignKey<ServicePricing>(d => d.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(d => d.Features)
                .WithOne(p => p.Service)
                .HasForeignKey<ServiceFeature>(d => d.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(r => r.Reviews)
                .WithOne(r => r.Service)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.ToTable("Subscriptions");
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Period)
                .WithOne(p => p.Subscription)
                .HasForeignKey<SubscriptionPeriod>(d => d.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(d => d.Pricing)
                .WithOne(p => p.Subscription)
                .HasForeignKey<SubscriptionPricing>(d => d.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<UsageRecord>(entity =>
        {
            entity.ToTable("UsageRecords");
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Metrics)
                .WithOne(p => p.UsageRecord)
                .HasForeignKey<UsageMetrics>(d => d.UsageRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payments");
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Details)
                .WithOne(p => p.Payment)
                .HasForeignKey<PaymentDetails>(d => d.PaymentId);
            entity.HasOne(d => d.Transaction)
                .WithOne(p => p.Payment)
                .HasForeignKey<PaymentTransaction>(d => d.PaymentId);
            entity.HasOne(d => d.Invoice)
                .WithOne(p => p.Payment)
                .HasForeignKey<Invoice>(d => d.PaymentId);
        });
        
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoices");
            entity.HasKey(e => e.Id);
            entity.HasOne(d => d.Details)
                .WithOne(p => p.Invoice)
                .HasForeignKey<InvoiceDetails>(d => d.InvoiceId);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethods");
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews");
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.ReviewDetails)
                .WithOne(e => e.Review)
                .HasForeignKey<ReviewDetails>(d => d.ReviewId);
        });
    }
}