using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EFCore.Sqlite
{
    public class DataDbContext : DbContext
    {
        public DbSet<MyModel> MyModels => Set<MyModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
{
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //apply all configurations in this project
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Seed some data. Used when create migrations.
            //Any added data after initial migrations is added to the next migrations
            modelBuilder.Entity<MyModel>().HasData(new MyModel { Id = 1, Name = "Dave" });
            modelBuilder.Entity<MyModel>().HasData(new MyModel { Id = 2, Name = "Horse" });
        }
    }
}