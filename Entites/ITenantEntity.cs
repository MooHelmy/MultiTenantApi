namespace MyMultiTenantApi.Entites;

/// <summary>
/// Any entity that belongs to a company (tenant) must implement this
/// so a global query filter can isolate each company's data.
/// </summary>
public interface ITenantEntity
{
    Guid TenantId { get; set; }
}
