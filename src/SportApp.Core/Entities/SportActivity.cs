using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public class SportActivity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public float Distance { get; set; }

        public string Measure { get; set; }

        public DateTime? LastUpdate { get; set; }

        public SportType Type { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        private User User { get; set; }

        //[ForeignKey(nameof(Sport))]
        //public string SportId { get; set; }
        //Sport Sport { get; set; }
    }
}