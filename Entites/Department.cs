namespace MyMultiTenantApi.Entites;

/// <summary>A department inside a company, e.g. Billing, Technical Support.</summary>
public class Department : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? SupportEmail { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<DepartmentMember> Members { get; set; } = new List<DepartmentMember>();
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

/// <summary>An agent who belongs to a department. A user can be in several departments of the same company.</summary>
public class DepartmentMember : ITenantEntity
{
    public Guid TenantId { get; set; }

    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public bool IsLead { get; set; }
}
