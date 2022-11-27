using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public class Route
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageURl { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Site { get; set; } = string.Empty;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        private User User { get; set; }
    }
}