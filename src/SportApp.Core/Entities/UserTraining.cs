using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public class UserTraining
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(Training))]
        public long TrainingId { get; set; }

        public Training Training { get; set; }
    }
}