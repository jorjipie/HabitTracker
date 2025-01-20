using Microsoft.Identity.Client;
using System.Security.Claims;

namespace HabitTracker.Models
{
    public class Habit
    {
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
