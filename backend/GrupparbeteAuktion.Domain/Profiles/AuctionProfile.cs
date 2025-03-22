using AutoMapper;
using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Domain.Profiles
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<Auction, AuctionReadDTO>();
            CreateMap<AuctionCreateDTO, Auction>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<AuctionUpdateDTO, Auction>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<Auction, AuctionCreateDTO>();
        }
    }
}
