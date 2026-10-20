namespace MyMultiTenantApi.Entites;

public class TicketCategory : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public Guid? ParentCategoryId { get; set; }
    public TicketCategory? ParentCategory { get; set; }
    public ICollection<TicketCategory> SubCategories { get; set; } = new List<TicketCategory>();

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
