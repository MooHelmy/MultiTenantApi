namespace MyMultiTenantApi.Entites;

public enum BillingCycle
{
    Monthly = 1,
    Yearly = 2
}

public enum SubscriptionStatus
{
    Trial = 1,
    Active = 2,
    PastDue = 3,
    Cancelled = 4,
    Expired = 5
}

public class Subscription : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public Guid PlanId { get; set; }
    public Plan Plan { get; set; } = null!;

    public BillingCycle BillingCycle { get; set; } = BillingCycle.Monthly;
    public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Trial;

    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    public DateTime? TrialEndsAt { get; set; }
    public DateTime? CancelledAt { get; set; }
}
