using AutoMapper;
using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, Users>();
        }
    }
}
