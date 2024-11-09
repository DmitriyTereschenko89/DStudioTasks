using DStudioTasks.Domain.Common;

namespace DStudioTasks.Infrastructure.Services
{
    public class TaskService(ITaskRepository repository) : ITaskService
    {
        private readonly ITaskRepository _repository = repository;

        public async Task CreateTaskAsync(DStudioTasks.Domain.Entities.Task task)
        {
            await _repository.CreateTaskAsync(task);
        }

        public IEnumerable<DStudioTasks.Domain.Entities.Task> GetTasks()
        {
            return _repository.GetTasks();
        }
    }
}
