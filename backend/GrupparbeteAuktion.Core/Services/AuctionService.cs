using AutoMapper;
using GrupparbeteAuktion.Core.Interfaces;
using GrupparbeteAuktion.Data.Interfaces;
using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GrupparbeteAuktion.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepo _repo;
        private readonly IBidRepo _bidRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public AuctionService(IAuctionRepo repo, IBidRepo bidRepo, IMapper mapper, IWebHostEnvironment env)
        {
            _repo = repo;
            _bidRepo = bidRepo;
            _mapper = mapper;
            _env = env;
        }

        public AuctionReadDTO GetAuctionById(int auctionId)
        {
            var auction = _repo.GetAuctionById(auctionId);
            var bids = _bidRepo.GetBids(auctionId);

            if (auction == null)
                throw new Exception("Auction not found.");

            var auctionDto = _mapper.Map<AuctionReadDTO>(auction);
            var bidDtos = new List<BidReadDTO>();

            foreach (var bid in bids)
                bidDtos.Add(_mapper.Map<BidReadDTO>(bid));

            //om den är stängd visa utan budhistorik
            if (IsClosed(auction))
            {
                return auctionDto;
            }
            //annars visa med budhistorik
            else
            {
                auctionDto.Bids = bidDtos;
                return auctionDto;
            }
        }

        public List<Auction> SearchAuctions(string condition)
        {
            var matchedAuctions = _repo.SearchAuction(condition);

            foreach(var auction in matchedAuctions)
            {
                _mapper.Map<AuctionReadDTO>(auction);
            }

            return matchedAuctions;
        }

        public void AddAuction(int userId, AuctionCreateDTO auctionDto)
        {
            var auction = _mapper.Map<Auction>(auctionDto);
            auction.StartTime = DateTime.Now;

            if (auction.StartTime > auction.EndTime)
            {
                throw new Exception("End time can't be earlier than start time.");
            }

            auction.UserID = userId;
            auction.Image = SaveImage(auctionDto.Image);

            _repo.InsertItem(auction);
        }

        public void UpdateAuction(int userId, AuctionUpdateDTO auctionDto)
        {
            var auctionToUpdate = _repo.GetAuctionById(auctionDto.AuctionID);
            var bids = _bidRepo.GetBids(auctionDto.AuctionID);

            var auction = _mapper.Map<Auction>(auctionDto);
            auction.StartTime = DateTime.Now;
            auction.UserID = userId;
            auction.Image = SaveImage(auctionDto.Image);
            DeleteImage(auctionToUpdate.Image);

            if (bids.Any() && auctionDto.AuctionPrice != auctionToUpdate.AuctionPrice)
               throw new Exception("Cannot update price if there are bids.");

            _repo.UpdateItem(auction);
        }

        public void DeleteAuction(int auctionId)
        {
            var auctionToDelete = _repo.GetAuctionById(auctionId);
            var bids = _bidRepo.GetBids(auctionId);

            if (bids.Any())
                throw new Exception("Cannot delete auction with bids.");

            DeleteImage(auctionToDelete.Image);

            _repo.DeleteItem(auctionId);
        }

        public List<Auction> GetAuctionsByUserID(int userID)
        {
            var auctions = _repo.GetAuctionsByUserID(userID);

            return auctions;
        }

        public bool IsClosed(Auction auction)
        {
            if (auction.EndTime < DateTime.Now)
                return true;
            else
                return false;
        }

        public string SaveImage(IFormFile image)
        {

            var uploadDirectory = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadDirectory, fileName);

            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("File path is null or empty. " + _env.WebRootPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            //var fileUrl = "/uploads/" + fileName;

            return fileName;
        }

        public void DeleteImage(string fileName)
        {
            var uploadDirectory = Path.Combine(_env.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadDirectory, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new Exception("File not found: " + filePath);
            }
        }
    }
}
