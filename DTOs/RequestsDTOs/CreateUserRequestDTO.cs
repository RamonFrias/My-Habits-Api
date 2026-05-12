using System.ComponentModel.DataAnnotations;

namespace MyHabitsApi.DTOs.RequestsDTOs
{
    public class CreateUserRequestDTO
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
