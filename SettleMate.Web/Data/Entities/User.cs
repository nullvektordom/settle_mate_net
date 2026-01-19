using Microsoft.AspNetCore.Identity;

namespace SettleMate.Web.Data.Entities;

public class User : IdentityUser<System.Guid>
{
    public ICollection<HouseHoldMember> HouseHoldMembers { get; set; } = [];
}