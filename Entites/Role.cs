namespace MyMultiTenantApi.Entites;

public class Role : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    /// <summary>System roles (e.g. CompanyAdmin) can't be edited or deleted.</summary>
    public bool IsSystemRole { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
