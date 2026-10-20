namespace MyMultiTenantApi.Entites;

public class TicketComment : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public string Body { get; set; } = string.Empty;

    /// <summary>Internal notes are visible to agents only, not the customer.</summary>
    public bool IsInternal { get; set; }

    // Author is either an agent (User) or the Customer
    public Guid? AuthorUserId { get; set; }
    public User? AuthorUser { get; set; }

    public Guid? AuthorCustomerId { get; set; }
    public Customer? AuthorCustomer { get; set; }

    public ICollection<TicketAttachment> Attachments { get; set; } = new List<TicketAttachment>();
}
