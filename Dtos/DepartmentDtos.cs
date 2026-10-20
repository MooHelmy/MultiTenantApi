using System.ComponentModel.DataAnnotations;

namespace MyMultiTenantApi.Dtos;

// ---------- Department ----------

public record DepartmentSummaryDto(Guid Id, string Name);

public record DepartmentDto(
    Guid Id,
    string Name,
    string? Description,
    string? SupportEmail,
    bool IsActive,
    int MembersCount,
    DateTime CreatedAt);

public record CreateDepartmentDto
{
    [Required, MaxLength(150)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; init; }

    [EmailAddress]
    public string? SupportEmail { get; init; }
}

public record UpdateDepartmentDto
{
    [Required, MaxLength(150)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; init; }

    [EmailAddress]
    public string? SupportEmail { get; init; }

    public bool IsActive { get; init; } = true;
}

// ---------- Department Members ----------

public record DepartmentMemberDto(
    Guid UserId,
    string FullName,
    string Email,
    bool IsLead);

public record AddDepartmentMemberDto
{
    [Required]
    public Guid UserId { get; init; }

    public bool IsLead { get; init; }
}
