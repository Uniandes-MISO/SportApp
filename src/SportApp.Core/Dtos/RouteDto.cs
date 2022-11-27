namespace SportApp.Core.Dtos
{
    public class RouteDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageURl { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Site { get; set; } = string.Empty;
    }
}