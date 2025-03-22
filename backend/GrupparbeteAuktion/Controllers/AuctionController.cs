using GrupparbeteAuktion.Core.Interfaces;
using GrupparbeteAuktion.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace GrupparbeteAuktion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet("{auctionId}")]
        public IActionResult GetAuctionByID(int auctionId)
        {
            try
            {
                var auction = _auctionService.GetAuctionById(auctionId);
                return Ok(auction);
            }
            catch (Exception ex)
            {
                return NotFound(new { ex.Message });
            }
        }

        [Authorize]
        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public IActionResult PostAuction([FromForm] AuctionCreateDTO auctionDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (auctionDto.Image == null || auctionDto.Image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                _auctionService.AddAuction(userId, auctionDto);
                return Ok(new { message = "Auction created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Authorize]
        [HttpPut("update")]
        [Consumes("multipart/form-data")]
        public IActionResult UpdateAuction([FromForm] AuctionUpdateDTO auctionDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            try
            {
                _auctionService.UpdateAuction(userId, auctionDto);
                return Ok("Post has been updated");
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteAction(int auctionid)
        {
            try
            {
                _auctionService.DeleteAuction(auctionid);
                return Ok("Auction has been deleted");
            }
            catch (Exception ex)
            {
                return BadRequest( new { ex.Message });
            }
            
        }

        [HttpGet("search")]
        public IActionResult SearchAuctions(string condition)
        {
            try
            {
                var foundAuctions = _auctionService.SearchAuctions(condition);
                return Ok(foundAuctions);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [Authorize]
        [HttpGet("userId")]
        public IActionResult GetAuctionsByUserID()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var auctions = _auctionService.GetAuctionsByUserID(userId);
            return Ok(auctions);
        }
    }
}
