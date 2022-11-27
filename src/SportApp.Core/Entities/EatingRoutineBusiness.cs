using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public class EatingRoutineBusiness
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey(nameof(EatingRoutine))]
        public long EatingRoutineId { get; set; }

        public EatingRoutine EatingRoutine { get; set; }

        [ForeignKey(nameof(Service))]
        public long ServiceId { get; set; }

        public Service Service { get; set; }
    }
}