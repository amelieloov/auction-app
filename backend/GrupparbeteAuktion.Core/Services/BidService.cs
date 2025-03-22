using AutoMapper;
using GrupparbeteAuktion.Core.Interfaces;
using GrupparbeteAuktion.Data.Interfaces;
using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Core.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepo _bidRepo;
        private readonly IAuctionRepo _auctionRepo;
        private readonly IAuctionService _auctionService;
        private readonly IMapper _mapper;

        public BidService(IBidRepo bidRepo, IAuctionRepo auctionRepo, IAuctionService auctionService, IMapper mapper)
        {
            _bidRepo = bidRepo;
            _auctionRepo = auctionRepo;
            _auctionService = auctionService;
            _mapper = mapper;
        }

        public void AddBid(int userId, BidCreateDTO bidDto)
        {
            var auction = _auctionRepo.GetAuctionById(bidDto.AuctionID);

            if (bidDto.BidPrice < auction.AuctionPrice)
                throw new Exception("Bid must be higher than previous bid.");

            if (auction.UserID == userId)
                throw new Exception("Cannot bid on one's own auction.");

            if (_auctionService.IsClosed(auction))
                throw new Exception("The auction is closed.");

            auction.AuctionPrice = bidDto.BidPrice;
            _auctionRepo.UpdateItem(auction);

            var bid = _mapper.Map<Bid>(bidDto);
            bid.UserID = userId;

            _bidRepo.AddBid(bid);
        }

        public void DeleteBid(int bidId)
        {
            var bid = _bidRepo.GetBidByID(bidId);
            var auction = _auctionRepo.GetAuctionById(bid.AuctionID);

            if (_auctionService.IsClosed(auction))
                throw new Exception("The auction is closed.");

            _bidRepo.DeleteBid(bidId);
        }

        public List<Bid> GetBidsByUserID(int userID)
        {
            var bids = _bidRepo.GetBidsByUserID(userID);

            return bids;
        }
    }
}
