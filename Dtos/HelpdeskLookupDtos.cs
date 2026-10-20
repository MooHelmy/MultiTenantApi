using System.ComponentModel.DataAnnotations;
using MyMultiTenantApi.Entites;

namespace MyMultiTenantApi.Dtos;

// ---------- Customer ----------

public record CustomerDto(
    Guid Id,
    string FullName,
    string Email,
    string? PhoneNumber,
    string? CompanyName,
    string? Notes,
    DateTime CreatedAt);

public record CreateCustomerDto
{
    [Required, MaxLength(150)]
    public string FullName { get; init; } = string.Empty;

    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; init; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; init; }

    [MaxLength(200)]
    public string? CompanyName { get; init; }

    [MaxLength(2000)] // Anotation way to limit the length of the Notes property to 2000 characters
    public string? Notes { get; init; }
}

public record UpdateCustomerDto
{
    [Required, MaxLength(150)]
    public string FullName { get; init; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; init; }

    [MaxLength(200)]
    public string? CompanyName { get; init; }

    [MaxLength(2000)]
    public string? Notes { get; init; }
}

// ---------- Ticket Category ----------

public record TicketCategoryDto(
    Guid Id,
    string Name,
    string? Description,
    Guid? ParentCategoryId);

public record CreateTicketCategoryDto
{
    [Required, MaxLength(150)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; init; }

    public Guid? ParentCategoryId { get; init; }
}

public record UpdateTicketCategoryDto
{
    [Required, MaxLength(150)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; init; }

    public Guid? ParentCategoryId { get; init; }
}

// ---------- Tag ----------

public record TagDto(Guid Id, string Name, string? Color);

public record CreateTagDto
{
    [Required, MaxLength(50)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(20)]
    public string? Color { get; init; }
}

public record UpdateTagDto
{
    [Required, MaxLength(50)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(20)]
    public string? Color { get; init; }
}

// ---------- SLA Policy ----------

public record SlaPolicyDto(
    Guid Id,
    string Name,
    TicketPriority Priority,
    int FirstResponseMinutes,
    int ResolutionMinutes,
    bool IsActive);

public record CreateSlaPolicyDto
{
    [Required, MaxLength(150)]
    public string Name { get; init; } = string.Empty;

    public TicketPriority Priority { get; init; }

    [Range(1, int.MaxValue)]
    public int FirstResponseMinutes { get; init; }

    [Range(1, int.MaxValue)]
    public int ResolutionMinutes { get; init; }
}

public record UpdateSlaPolicyDto
{
    [Required, MaxLength(150)]
    public string Name { get; init; } = string.Empty;

    public TicketPriority Priority { get; init; }

    [Range(1, int.MaxValue)]
    public int FirstResponseMinutes { get; init; }

    [Range(1, int.MaxValue)]
    public int ResolutionMinutes { get; init; }

    public bool IsActive { get; init; } = true;
}
