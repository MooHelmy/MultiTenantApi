using System.ComponentModel.DataAnnotations;

namespace MyMultiTenantApi.Dtos;

// ---------- User ----------
// Note: PasswordHash is never exposed in any DTO.

public record UserDto(
    Guid Id,
    string FullName,
    string Email,
    string? PhoneNumber,
    bool IsActive,
    bool IsEmailConfirmed,
    DateTime? LastLoginAt,
    IReadOnlyList<string> Roles,
    IReadOnlyList<DepartmentSummaryDto> Departments);

public record CreateUserDto
{
    [Required, MaxLength(150)]
    public string FullName { get; init; } = string.Empty;

    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; init; } = string.Empty;

    [Required, MinLength(8), MaxLength(100)]
    public string Password { get; init; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; init; }

    public List<Guid> RoleIds { get; init; } = new();
    public List<Guid> DepartmentIds { get; init; } = new();
}

public record UpdateUserDto
{
    [Required, MaxLength(150)]
    public string FullName { get; init; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; init; }

    public bool IsActive { get; init; } = true;
}

public record ChangePasswordDto
{
    [Required]
    public string CurrentPassword { get; init; } = string.Empty;

    [Required, MinLength(8), MaxLength(100)]
    public string NewPassword { get; init; } = string.Empty;
}

public record AssignUserRolesDto
{
    [Required]
    public List<Guid> RoleIds { get; init; } = new();
}

// ---------- Role ----------

public record RoleDto(
    Guid Id,
    string Name,
    string? Description,
    bool IsSystemRole);

public record CreateRoleDto
{
    [Required, MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; init; }
}

public record UpdateRoleDto
{
    [Required, MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; init; }
}
