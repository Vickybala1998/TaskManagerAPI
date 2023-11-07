using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<User> _users { get; set; }

        public DbSet<TaskDetails> _tasks { get; set; }

        public DbSet<Notification> _notifications { get; set; }

        //To map the table -- used for custom table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("_users");
            modelBuilder.Entity<TaskDetails>().ToTable("_tasks");
        }

    }
}
