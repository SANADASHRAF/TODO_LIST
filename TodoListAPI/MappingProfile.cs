using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace TodoListAPI
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            CreateMap<RegisterUserDto, User>().ReverseMap();
            CreateMap<RegisterUserResponseDto, User>().ReverseMap();

            CreateMap<UserLoginResponseDto, User>().ReverseMap();

            // static
            CreateMap<TaskPriority, TaskPriorityDto>();
            CreateMap<TaskCategory, TaskCategoryDto>();
            CreateMap<Status, StatusDto>();

            // tasks
            CreateMap<Tasks, TaskDto>()
            .ForMember(dest => dest.TaskStatusName, opt => opt.MapFrom(src => src.TaskStatus.Name))
            .ForMember(dest => dest.TaskCategoryName, opt => opt.MapFrom(src => src.TaskCategory.Name))
            .ForMember(dest => dest.TaskPriorityName, opt => opt.MapFrom(src => src.TaskPriority.Name));
            CreateMap<CreateTaskDto, Tasks>();
            CreateMap<UpdateTaskDto, Tasks>();
        }
    }
}
