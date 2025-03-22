using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace GrupparbeteAuktion.Core.Interfaces
{
    public interface IAuctionService
    {
        public AuctionReadDTO GetAuctionById(int auctionId);
        public List<Auction> SearchAuctions(string condition);
        public void AddAuction(int userId, AuctionCreateDTO auctionDto);
        public void UpdateAuction(int userId, AuctionUpdateDTO auctionDto);
        public void DeleteAuction(int auctionId);
        public bool IsClosed(Auction auction);
        public List<Auction> GetAuctionsByUserID(int userID);
    }
}
