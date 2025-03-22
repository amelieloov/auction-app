using AutoMapper;
using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Domain.Profiles
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            CreateMap<BidCreateDTO, Bid>();
            CreateMap<Bid, BidReadDTO>();
        }
    }
}
