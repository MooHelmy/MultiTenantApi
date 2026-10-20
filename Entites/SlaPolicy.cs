namespace MyMultiTenantApi.Entites;

/// <summary>Service-level agreement targets per priority.</summary>
public class SlaPolicy : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; }

    public int FirstResponseMinutes { get; set; }
    public int ResolutionMinutes { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
