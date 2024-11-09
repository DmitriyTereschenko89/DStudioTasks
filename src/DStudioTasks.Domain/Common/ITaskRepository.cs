namespace DStudioTasks.Domain.Common
{
    public interface ITaskRepository
    {
        IEnumerable<DStudioTasks.Domain.Entities.Task> GetTasks();
        Task CreateTaskAsync(DStudioTasks.Domain.Entities.Task task);
    }
}
