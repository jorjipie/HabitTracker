
using HabitTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker
{
    public class DbStartup : IHostedService
    {
        private ConfigurationManager _config;
        private string _connectionString { get; set; }
        public DbStartup(ConfigurationManager config) {
            _config = config;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            string dbfile = "./habittracker.db";
            if (!File.Exists(dbfile))
            {
                File.Create(dbfile).Close();
            }

            if (IsFileInUseGeneric(dbfile))
            {
                int retryCount = 0, retryMax = 60;
                bool success = false;
                Console.WriteLine($"Waiting for {dbfile} ...");
                while (retryCount < retryMax && !success)
                {
                    Thread.Sleep(500);
                    success = !IsFileInUseGeneric(dbfile);
                    retryCount++;
                }
                if (retryCount == retryMax)
                {
                    throw new Exception($"Unable to write to {dbfile}s");
                }
            }
            
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            if (_config is not null)
            {
                optionsBuilder.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            }
            AppDbContext context = new AppDbContext(options: optionsBuilder.Options);
            context.Database.Migrate();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private static bool IsFileInUseGeneric(string filename)
        {
            try
            {
                using var stream = File.Open(filename, FileMode.Open);
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }
    }
}
