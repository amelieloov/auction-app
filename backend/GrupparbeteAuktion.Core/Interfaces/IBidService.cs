using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Core.Interfaces
{
    public interface IBidService
    {
        public void AddBid(int userId, BidCreateDTO bidDto);
        public void DeleteBid(int bidId);
        public List<Bid> GetBidsByUserID(int userID);
    }
}
