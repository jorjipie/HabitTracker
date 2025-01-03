
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
            string BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dbFilePath;
            string dbfilename = "habittracker.db";
            if (BaseDir.Substring(0, 1) == "/") { // *nix
                dbFilePath = Path.Combine(BaseDir, dbfilename);
            }
            else if (BaseDir.IndexOf("\\bin") != 0) { // windows
                dbFilePath = Path.GetFullPath(Path.Combine(BaseDir, @"..\..\..\" + dbfilename));
            }
            else
            { //not sure how we'd get here.
                throw new Exception("Oh no!");
            }
            Console.WriteLine(dbFilePath);
            if (!File.Exists(dbFilePath))
            {
                File.Create(dbFilePath).Close();
            }

            if (IsFileInUseGeneric(dbFilePath))
            {
                int retryCount = 0, retryMax = 60;
                bool success = false;
                Console.WriteLine($"Waiting for {dbFilePath} ...");
                while (retryCount < retryMax && !success)
                {
                    Thread.Sleep(500);
                    success = !IsFileInUseGeneric(dbFilePath);
                    retryCount++;
                }
                if (retryCount == retryMax)
                {
                    throw new Exception($"Unable to write to {dbFilePath}s");
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
