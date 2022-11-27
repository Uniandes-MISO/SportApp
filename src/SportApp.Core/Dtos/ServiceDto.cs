namespace SportApp.Core.Dtos
{
    public class ServiceDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string SportType { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
    }
}