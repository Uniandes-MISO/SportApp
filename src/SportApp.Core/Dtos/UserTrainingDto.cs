namespace SportApp.Core.Dtos
{
    public class UserTrainingDto
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        public long TrainingId { get; set; }
        public TrainingDto Training { get; set; }
    }
}