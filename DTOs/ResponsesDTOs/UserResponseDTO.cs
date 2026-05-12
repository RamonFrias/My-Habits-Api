using System.ComponentModel.DataAnnotations;

namespace MyHabitsApi.DTOs.ResponsesDTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
