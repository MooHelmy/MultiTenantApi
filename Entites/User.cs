namespace MyMultiTenantApi.Entites;

/// <summary>Staff account (agent, supervisor, admin) belonging to one company.</summary>
public class User : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsEmailConfirmed { get; set; }
    public DateTime? LastLoginAt { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<DepartmentMember> DepartmentMemberships { get; set; } = new List<DepartmentMember>();
}
