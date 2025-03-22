using GrupparbeteAuktion.Core.Interfaces;
using GrupparbeteAuktion.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GrupparbeteAuktion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBid(BidCreateDTO bidDto) 
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            try
            {
                _bidService.AddBid(userId, bidDto);
                return Ok("Bid succesfully added!");
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
            
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteBid(int bidId)
        {
            try
            {
                _bidService.DeleteBid(bidId);
                return Ok("Bid succesfully removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }   
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetBidsByUserID()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var bids = _bidService.GetBidsByUserID(userId);

            return Ok(bids);
        }
    }
}