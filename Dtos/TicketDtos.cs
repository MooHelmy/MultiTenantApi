using System.ComponentModel.DataAnnotations;
using MyMultiTenantApi.Entites;

namespace MyMultiTenantApi.Dtos;

// ---------- Ticket ----------

/// <summary>Lightweight version used in ticket lists.</summary>
public record TicketDto(
    Guid Id,
    int TicketNumber,
    string Subject,
    TicketStatus Status,
    TicketPriority Priority,
    TicketChannel Channel,
    Guid CustomerId,
    string CustomerName,
    Guid DepartmentId,
    string DepartmentName,
    Guid? AssignedToUserId,
    string? AssignedToUserName,
    Guid? CategoryId,
    string? CategoryName,
    DateTime? DueAt,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

/// <summary>Full ticket with comments, attachments, tags and history.</summary>
public record TicketDetailsDto(
    Guid Id,
    int TicketNumber,
    string Subject,
    string Description,
    TicketStatus Status,
    TicketPriority Priority,
    TicketChannel Channel,
    CustomerDto Customer,
    DepartmentSummaryDto Department,
    Guid? AssignedToUserId,
    string? AssignedToUserName,
    TicketCategoryDto? Category,
    SlaPolicyDto? SlaPolicy,
    Guid? CreatedByUserId,
    DateTime? DueAt,
    DateTime? FirstResponseAt,
    DateTime? ResolvedAt,
    DateTime? ClosedAt,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IReadOnlyList<TagDto> Tags,
    IReadOnlyList<TicketCommentDto> Comments,
    IReadOnlyList<TicketAttachmentDto> Attachments,
    IReadOnlyList<TicketActivityDto> Activities);

public record CreateTicketDto
{
    [Required, MaxLength(250)]
    public string Subject { get; init; } = string.Empty;

    [Required, MaxLength(10000)]
    public string Description { get; init; } = string.Empty;

    [Required]
    public Guid CustomerId { get; init; }

    [Required]
    public Guid DepartmentId { get; init; }

    public TicketPriority Priority { get; init; } = TicketPriority.Medium;
    public TicketChannel Channel { get; init; } = TicketChannel.Web;

    public Guid? CategoryId { get; init; }
    public Guid? AssignedToUserId { get; init; }
    public List<Guid> TagIds { get; init; } = new();
}

public record UpdateTicketDto
{
    [Required, MaxLength(250)]
    public string Subject { get; init; } = string.Empty;

    [Required, MaxLength(10000)]
    public string Description { get; init; } = string.Empty;

    public TicketPriority Priority { get; init; }
    public Guid? CategoryId { get; init; }
    public List<Guid> TagIds { get; init; } = new();
}

public record ChangeTicketStatusDto
{
    public TicketStatus Status { get; init; }
}

public record AssignTicketDto
{
    /// <summary>Null = unassign.</summary>
    public Guid? AssignedToUserId { get; init; }
}

public record MoveTicketDto
{
    /// <summary>Move the ticket to another department of the same company.</summary>
    [Required]
    public Guid DepartmentId { get; init; }
}

// ---------- Ticket Comment ----------

public record TicketCommentDto(
    Guid Id,
    Guid TicketId,
    string Body,
    bool IsInternal,
    Guid? AuthorUserId,
    string? AuthorUserName,
    Guid? AuthorCustomerId,
    string? AuthorCustomerName,
    DateTime CreatedAt);

public record CreateTicketCommentDto
{
    [Required, MaxLength(10000)]
    public string Body { get; init; } = string.Empty;

    /// <summary>Internal notes are visible to agents only.</summary>
    public bool IsInternal { get; init; }
}

// ---------- Ticket Attachment ----------

public record TicketAttachmentDto(
    Guid Id,
    Guid TicketId,
    Guid? CommentId,
    string FileName,
    string ContentType,
    long SizeInBytes,
    Guid? UploadedByUserId,
    DateTime CreatedAt);

// ---------- Ticket Activity ----------

public record TicketActivityDto(
    Guid Id,
    Guid TicketId,
    Guid? PerformedByUserId,
    string? PerformedByUserName,
    string Field,
    string? OldValue,
    string? NewValue,
    DateTime CreatedAt);
