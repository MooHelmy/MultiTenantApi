namespace MyMultiTenantApi.Entites;

/// <summary>Audit trail of changes on a ticket (status, assignee, priority...).</summary>
public class TicketActivity : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public Guid? PerformedByUserId { get; set; }
    public User? PerformedByUser { get; set; }

    /// <summary>e.g. "Status", "Priority", "AssignedTo"</summary>
    public string Field { get; set; } = string.Empty;
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
}
