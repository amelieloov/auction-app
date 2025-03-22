using System.ComponentModel.DataAnnotations;

namespace GrupparbeteAuktion.Domain.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // Navigation Property för Bids
        public List<Bid> Bids { get; set; }

        public Users()
        {
        }

        public Users(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Users(int userID, string userName, string password)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
        }
    }
    
}
