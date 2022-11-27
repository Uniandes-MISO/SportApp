namespace SportApp.Core.Dtos
{
    public class EventDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageURl { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Site { get; set; } = string.Empty;
    }
}