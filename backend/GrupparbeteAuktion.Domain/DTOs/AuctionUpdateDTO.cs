using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupparbeteAuktion.Domain.DTOs
{
    public class AuctionUpdateDTO
    {
        public int AuctionID { get; set; }
        public string AuctionTitle { get; set; }
        public string AuctionDescription { get; set; }
        public decimal AuctionPrice { get; set; }
        public DateTime EndTime { get; set; }
        public IFormFile Image { get; set; }
    }
}
