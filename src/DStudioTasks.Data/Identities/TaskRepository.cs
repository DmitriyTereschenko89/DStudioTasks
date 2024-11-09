using DStudioTasks.Domain.Common;

namespace DStudioTasks.Data.Identities
{
    public class TaskRepository(TaskDbContext dbContext) : ITaskRepository
    {
        private readonly TaskDbContext _dbContext = dbContext;
        public async Task CreateTaskAsync(DStudioTasks.Domain.Entities.Task task)
        {
            _ = _dbContext.Tasks.Add(task);
            _ = await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<DStudioTasks.Domain.Entities.Task> GetTasks()
        {
            return _dbContext.Tasks;
        }
    }
}
