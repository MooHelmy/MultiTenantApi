namespace MyMultiTenantApi.Entites;

public class Ticket : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    /// <summary>The department (inside the company) that owns this ticket.</summary>
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;

    /// <summary>Human-friendly sequential number per company (e.g. #1042).</summary>
    public int TicketNumber { get; set; }

    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public TicketStatus Status { get; set; } = TicketStatus.New;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public TicketChannel Channel { get; set; } = TicketChannel.Web;

    // Requester
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Assignment (should be a member of the ticket's department)
    public Guid? AssignedToUserId { get; set; }
    public User? AssignedToUser { get; set; }

    public Guid? CategoryId { get; set; }
    public TicketCategory? Category { get; set; }

    public Guid? SlaPolicyId { get; set; }
    public SlaPolicy? SlaPolicy { get; set; }

    // Audit
    public Guid? CreatedByUserId { get; set; }
    public User? CreatedByUser { get; set; }

    // Lifecycle / SLA tracking
    public DateTime? DueAt { get; set; }
    public DateTime? FirstResponseAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
    public ICollection<TicketAttachment> Attachments { get; set; } = new List<TicketAttachment>();
    public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
    public ICollection<TicketActivity> Activities { get; set; } = new List<TicketActivity>();
}
