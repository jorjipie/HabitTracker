namespace HabitTracker.Models
{
    public class HabitToday : Habit
    { 
        public bool Completed { get; set; }
        public HabitToday(Habit habit)
        {
            this.Id = habit.Id;
            this.Name = habit.Name;
            this.CreatedAt = habit.CreatedAt;
            this.Completed = false;
        }
    }
}
