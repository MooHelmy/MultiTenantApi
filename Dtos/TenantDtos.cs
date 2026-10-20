using System.ComponentModel.DataAnnotations;

namespace MyMultiTenantApi.Dtos;

// ---------- Tenant (Company) ----------

public record TenantDto(
    Guid Id,
    string Name,
    string Identifier,
    string? LogoUrl,
    string? ContactEmail,
    string? ContactPhone,
    bool IsActive,
    DateTime CreatedAt);

public record CreateTenantDto
{
    [Required, MaxLength(200)]
    public string Name { get; init; } = string.Empty;

    [Required, MaxLength(100)]
    public string Identifier { get; init; } = string.Empty;

    [MaxLength(500)]
    public string? LogoUrl { get; init; }

    [EmailAddress]
    public string? ContactEmail { get; init; }

    [Phone]
    public string? ContactPhone { get; init; }
}

public record UpdateTenantDto
{
    [Required, MaxLength(200)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(500)]
    public string? LogoUrl { get; init; }

    [EmailAddress]
    public string? ContactEmail { get; init; }

    [Phone]
    public string? ContactPhone { get; init; }

    public bool IsActive { get; init; } = true;
}

// ---------- Tenant Domain ----------

public record TenantDomainDto(
    Guid Id,
    string Domain,
    bool IsPrimary,
    bool IsVerified);

public record CreateTenantDomainDto
{
    [Required, MaxLength(255)]
    public string Domain { get; init; } = string.Empty;

    public bool IsPrimary { get; init; }
}
