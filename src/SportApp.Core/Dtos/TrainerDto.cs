namespace SportApp.Core.Dtos
{
    public class TrainerDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public List<object> available { get; set; }
    }
}