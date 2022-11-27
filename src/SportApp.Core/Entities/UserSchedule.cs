using System.ComponentModel.DataAnnotations.Schema;

namespace SportApp.Core.Entities
{
    public enum Hour
    {
        Seis = 1,
        Siete = 2,
        Ocho = 3,
        Nueve = 4,
        Dies = 5,
        Once = 6,
        Doce = 7,
        Trece = 8,
        Catorce = 9,
        Quince = 10,
        Dieciseis = 11,
        Diecisiete = 12
    }

    public class UserSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Hour Type { get; set; }

        public DateOnly Date { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}