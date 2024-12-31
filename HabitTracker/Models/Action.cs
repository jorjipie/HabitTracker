namespace HabitTracker.Models
{
    public class Action
    {
        public DateTime CreatedAt { get; set; }
        public Habit Habit { get; set; }
        public Guid Id { get; set; }
        public Action() { }
        public Action(Habit habit)
        {
            CreatedAt = DateTime.Now;
            Id = Guid.NewGuid();
            this.Habit = habit;
        }
    }
}
