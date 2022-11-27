using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [ForeignKey(nameof(MembershipPlan))]
    public long? MembershipPlanId { get; set; }

    public MembershipPlan? MembershipPlan { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}