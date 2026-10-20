namespace MyMultiTenantApi.Entites;

public class TenantDomain : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    /// <summary>e.g. acme.myapp.com or app.acme.com</summary>
    public string Domain { get; set; } = string.Empty;

    public bool IsPrimary { get; set; }
    public bool IsVerified { get; set; }
}
