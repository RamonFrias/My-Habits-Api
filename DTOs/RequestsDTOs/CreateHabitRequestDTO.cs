using MyHabitsApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyHabitsApi.DTOs.RequestsDTOs
{
    public class CreateHabitRequestDTO
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public HabitFrequency Frequency { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
