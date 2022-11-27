namespace SportApp.Core.Dtos
{
    public class ActivityDto
    {
        public long Id { get; set; }

        public long Order { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public long TrainingId { get; set; }

        //public TrainingDto Training { get; set; }
    }
}