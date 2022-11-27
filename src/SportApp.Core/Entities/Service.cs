using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public enum ServiceType
    {
        Sportsman = 1,
        Coach = 2,
        Feeding = 3,
        Transportation = 4,
        Companion = 5
    }

    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ServiceType Type { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public SportType SportType { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        private User User { get; set; }
    }
}