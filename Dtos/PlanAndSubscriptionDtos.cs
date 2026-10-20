using System.ComponentModel.DataAnnotations;
using MyMultiTenantApi.Entites;

namespace MyMultiTenantApi.Dtos;

// ---------- Plan ----------

public record PlanDto(
    Guid Id,
    string Name,
    string? Description,
    decimal MonthlyPrice,
    decimal YearlyPrice,
    int MaxUsers,
    int MaxStorageMb,
    bool IsActive);

public record CreatePlanDto
{
    [Required, MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; init; }

    [Range(0, double.MaxValue)]
    public decimal MonthlyPrice { get; init; }

    [Range(0, double.MaxValue)]
    public decimal YearlyPrice { get; init; }

    [Range(1, int.MaxValue)]
    public int MaxUsers { get; init; }

    [Range(1, int.MaxValue)]
    public int MaxStorageMb { get; init; }
}

public record UpdatePlanDto
{
    [Required, MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; init; }

    [Range(0, double.MaxValue)]
    public decimal MonthlyPrice { get; init; }

    [Range(0, double.MaxValue)]
    public decimal YearlyPrice { get; init; }

    [Range(1, int.MaxValue)]
    public int MaxUsers { get; init; }

    [Range(1, int.MaxValue)]
    public int MaxStorageMb { get; init; }

    public bool IsActive { get; init; } = true;
}

// ---------- Subscription ----------

public record SubscriptionDto(
    Guid Id,
    Guid TenantId,
    Guid PlanId,
    string PlanName,
    BillingCycle BillingCycle,
    SubscriptionStatus Status,
    DateTime StartDate,
    DateTime? EndDate,
    DateTime? TrialEndsAt,
    DateTime? CancelledAt);

public record CreateSubscriptionDto
{
    [Required]
    public Guid TenantId { get; init; }

    [Required]
    public Guid PlanId { get; init; }

    public BillingCycle BillingCycle { get; init; } = BillingCycle.Monthly;

    public DateTime? StartDate { get; init; }
    public DateTime? TrialEndsAt { get; init; }
}

public record ChangeSubscriptionPlanDto
{
    [Required]
    public Guid PlanId { get; init; }

    public BillingCycle BillingCycle { get; init; } = BillingCycle.Monthly;
}
