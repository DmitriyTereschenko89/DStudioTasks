using Microsoft.EntityFrameworkCore;

namespace DStudioTasks.Data.Identities
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
            _ = Database.EnsureCreated();
        }

        public virtual DbSet<DStudioTasks.Domain.Entities.Task> Tasks { get; set; }
    }
}
