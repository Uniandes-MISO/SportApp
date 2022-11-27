using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public enum SportType
    {
        Cycling = 1,
        Athletics = 2
    }

    public class VirtualSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        public string AthleteId { get; set; }

        public User Athlete { get; set; }

        [ForeignKey(nameof(UserSchedule))]
        public int ScheduleId { get; set; }

        public UserSchedule Schedule { get; set; }

        public SportType Type { get; set; }

        [ForeignKey(nameof(User))]
        public string CoachId { get; set; }

        public User Coach { get; set; }
    }
}