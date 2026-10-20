namespace MyMultiTenantApi.Entites;

public class TicketAttachment : BaseEntity, ITenantEntity
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    /// <summary>Optional: set when the file was attached to a specific comment.</summary>
    public Guid? CommentId { get; set; }
    public TicketComment? Comment { get; set; }

    public string FileName { get; set; } = string.Empty;
    public string StoragePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long SizeInBytes { get; set; }

    public Guid? UploadedByUserId { get; set; }
    public User? UploadedByUser { get; set; }
}
