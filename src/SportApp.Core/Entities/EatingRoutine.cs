using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public class EatingRoutine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
    }
}