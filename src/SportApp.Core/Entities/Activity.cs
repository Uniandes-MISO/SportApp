using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long Order { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(Training))]
        public long TrainingId { get; set; }

        public Training Training { get; set; }
    }
}