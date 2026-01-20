namespace SettleMate.Web.Data.Entities;

public class Household
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateOnly CurrentMonth { get; set; }

    public ICollection<HouseHoldMember> Members { get; set; } = [];
    public ICollection<Transaction> Transactions { get; set; } = [];
}