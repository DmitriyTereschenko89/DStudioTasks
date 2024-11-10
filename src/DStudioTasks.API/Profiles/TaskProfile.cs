using AutoMapper;
using DStudioTasks.API.DataTransferObjects;

namespace DStudioTasks.API.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            _ = CreateMap<TaskDto, DStudioTasks.Domain.Entities.Task>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
