using AutoMapper;
using MyHabitsApi.Domains;
using MyHabitsApi.DTOs.RequestsDTOs;
using MyHabitsApi.DTOs.ResponsesDTOs;

namespace MyHabitsApi.Mapping
{
    public class ApiMappingDTOProfile : Profile
    {
        public ApiMappingDTOProfile()
        {
            CreateMap<CreateUserRequestDTO, User>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, User>().ReverseMap();
            CreateMap<UserResponseDTO, User>().ReverseMap();
            CreateMap<CreateHabitRequestDTO, Habit>().ReverseMap();
            CreateMap<UpdateHabitRequestDTO, Habit>().ReverseMap();
            CreateMap<HabitResponseDTO, Habit>().ReverseMap();
        }
    }
}
