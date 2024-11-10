using AutoMapper;
using DStudioTasks.API.DataTransferObjects;
using DStudioTasks.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace DStudioTasks.API.Controllers
{
    [ApiController]
    public class TasksController(ITaskService taskService, IMapper mapper) : Controller
    {
        private readonly ITaskService _taskService = taskService;
        private readonly IMapper _mapper = mapper;


        [HttpGet]
        [Route("/")]
        public IEnumerable<DStudioTasks.Domain.Entities.Task> GetTasks()
        {
            return _taskService.GetTasks();
        }

        [HttpPost]
        [Route("/")]
        public async Task Create([FromBody] TaskDto taskDto)
        {
            var task = _mapper.Map<DStudioTasks.Domain.Entities.Task>(taskDto);
            task.CreatedDate = DateTime.Now;
            task.LastModifiedDate = DateTime.Now;
            await _taskService.CreateTaskAsync(task);
        }
    }
}
