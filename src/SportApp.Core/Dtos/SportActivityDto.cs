using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SportApp.Core.Dtos
{
    public class SportActivityDto : SportActivityAddUpdateDto
    {
        public int Id { get; set; }
    }

    //public class SportActivityCreationDto : SportActivityAddUpdateDto
    //{
    //}

    //public class SportActivityUpdateDto : SportActivityAddUpdateDto
    //{
    //}

    public abstract class SportActivityAddUpdateDto
    {
        [Required(ErrorMessage = "Activity name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public float Distance { get; set; }

        public string Measure { get; set; }

        [Required(ErrorMessage = "Activity typr is a required field.")]
        public string Type { get; set; }

        public string UserId { get; set; }
    }
}