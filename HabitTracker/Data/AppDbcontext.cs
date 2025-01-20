using Microsoft.EntityFrameworkCore;
using HabitTracker.Models;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HabitTracker.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
    }
}
