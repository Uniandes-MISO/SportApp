namespace SportApp.Core.Dtos
{
    public class EatingRoutineUserDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public List<ServiceDto> Services { get; set; }
    }
}