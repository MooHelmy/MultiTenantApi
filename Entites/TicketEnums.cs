namespace MyMultiTenantApi.Entites;

public enum TicketStatus
{
    New = 1,
    Open = 2,
    Pending = 3,     // waiting for customer reply
    OnHold = 4,
    Resolved = 5,
    Closed = 6
}

public enum TicketPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Urgent = 4
}

public enum TicketChannel
{
    Web = 1,
    Email = 2,
    Phone = 3,
    Chat = 4,
    Api = 5
}
