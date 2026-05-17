using System.ComponentModel.DataAnnotations;

namespace MyHabitsApi.DTOs
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email name is required")]
        public string? Email { get; set; }
    }
}
