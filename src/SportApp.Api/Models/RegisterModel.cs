using System.ComponentModel.DataAnnotations;

namespace SportApp.Api.Models
{
    public class RegisterModel
    {
        //[Required(ErrorMessage = "User Name is required")]
        //public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Rol is required")]
        public string? Rol { get; set; }
    }
}