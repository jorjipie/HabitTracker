using Microsoft.EntityFrameworkCore;
using HabitTracker.Models;
using System.Diagnostics.CodeAnalysis;

namespace HabitTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
    }
}
