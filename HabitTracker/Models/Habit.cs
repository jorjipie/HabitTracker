using Microsoft.Identity.Client;

namespace HabitTracker.Models
{
    public class Habit
    {
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Id { get; set; }
    }
}
