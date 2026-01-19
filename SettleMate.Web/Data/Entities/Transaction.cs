namespace SettleMate.Web.Data.Entities;

public class Transaction
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid HouseHoldId { get; set; }
    public Household Household { get; set; } = null!;
    
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public Guid PayerId { get; set; }
    public User Payer { get; set; } = null!;
    
    public DateTime PaidAt { get; set; }
    public string? RecieptPath { get; set; }
    
    public string AppliedRatioJson { get; set; } = "{}";
    
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}