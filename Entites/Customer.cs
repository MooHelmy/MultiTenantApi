namespace MyMultiTenantApi.Entites;

/// <summary>The end customer / requester who opens tickets for a company.</summary>
public class Customer : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string? Notes { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
