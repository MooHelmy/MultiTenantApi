namespace MyMultiTenantApi.Entites;

public class Tag : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public string? Color { get; set; }

    public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
}

public class TicketTag : ITenantEntity
{
    public Guid TenantId { get; set; }

    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public Guid TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}
