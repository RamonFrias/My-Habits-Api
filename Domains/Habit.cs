using MyHabitsApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHabitsApi.Domains
{
    [Table("Habits")]
    public class Habit
    {
        [Key]
        public int Id { get; set; }
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
        public User User { get; set; }
    }
}
