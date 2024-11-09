using AutoMapper;
using DStudioTasks.API.Data_Transfer_Objects;

namespace DStudioTasks.API.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            _ = CreateMap<TaskDto, DStudioTasks.Domain.Entities.Task>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTimeOffset.Now))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(_ => DateTimeOffset.Now));
        }
    }
}
