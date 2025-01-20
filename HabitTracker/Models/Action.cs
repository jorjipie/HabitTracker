namespace HabitTracker.Models
{
    public class Action
    {
        public DateTime CreatedAt { get; set; }
        public Habit Habit { get; set; }
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public Action() { }
        public Action(Habit habit)
        {
            CreatedAt = DateTime.Now;
            UserID = habit.UserId;
            Id = Guid.NewGuid();
            this.Habit = habit;
        }
    }
}
