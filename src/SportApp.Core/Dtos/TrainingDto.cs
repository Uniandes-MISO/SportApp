namespace SportApp.Core.Dtos
{
    public class TrainingDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public List<ActivityDto> Activities { get; set; }
    }
}