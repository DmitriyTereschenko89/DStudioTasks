namespace DStudioTasks.Domain.Common
{
    public interface ITaskService
    {
        IEnumerable<DStudioTasks.Domain.Entities.Task> GetTasks();
        Task CreateTaskAsync(DStudioTasks.Domain.Entities.Task task);
    }
}
