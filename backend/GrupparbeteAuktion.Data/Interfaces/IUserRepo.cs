using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Data.Interfaces
{
    public interface IUserRepo
    {
        public void AddUser(string UserName, string Password);
        public void UpdateUser(int userID, int userName, int password);

        public void DeleteUser(int userID);

        public Users GetUser(int userID);


    }
}
