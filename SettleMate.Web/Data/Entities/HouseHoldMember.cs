using System.Runtime.CompilerServices;

namespace SettleMate.Web.Data.Entities;

public class HouseHoldMember
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public Guid HouseHoldId { get; set; }
    public Household Household { get; set; } = null!;    
    
    public decimal MonthlySalary { get; set; }
    public decimal SplitRatio { get; set; }
}