namespace MyMultiTenantApi.Entites;

/// <summary>The Tenant = a company using the helpdesk. Each company has its own departments, staff and tickets.</summary>
public class Tenant : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    /// <summary>Unique short key, e.g. used in subdomain or X-Tenant header.</summary>
    public string Identifier { get; set; } = string.Empty;

    public string? ConnectionString { get; set; }
    public string? LogoUrl { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<TenantDomain> Domains { get; set; } = new List<TenantDomain>();
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public ICollection<Department> Departments { get; set; } = new List<Department>();
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
