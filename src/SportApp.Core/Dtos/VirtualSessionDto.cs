namespace SportApp.Core.Dtos
{
    public class VirtualSessionDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string SportType { get; set; }

        public string AthleteId { get; set; }

        public string TrainerId { get; set; }

        public string HourKey { get; set; }
    }
}