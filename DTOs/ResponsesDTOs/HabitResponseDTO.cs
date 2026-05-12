using MyHabitsApi.Domains;
using MyHabitsApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyHabitsApi.DTOs.ResponsesDTOs
{
    public class HabitResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public HabitFrequency Frequency { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }
    }
}
