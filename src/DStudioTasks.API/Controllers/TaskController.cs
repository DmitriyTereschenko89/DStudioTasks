using AutoMapper;
using DStudioTasks.API.Data_Transfer_Objects;
using DStudioTasks.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace DStudioTasks.API.Controllers
{
    [ApiController]
    public class TaskController(ITaskService taskService, IMapper mapper) : Controller
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
        [Route("/add")]
        public async Task Create(TaskDto taskDto)
        {
            var task = _mapper.Map<DStudioTasks.Domain.Entities.Task>(taskDto);
            await _taskService.CreateTaskAsync(task);
        }
    }
}
