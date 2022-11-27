using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public enum PlanType
    {
        Free = 1,
        Medium = 2,
        Premium = 3
    }

    public class MembershipPlan
    {
        //[Column("MembershipPlanId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public PlanType Type { get; set; }

        public bool Active { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        private User User { get; set; }
    }
}