using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;

namespace GrupparbeteAuktion.Core.Interfaces
{
    public interface IUserService
    {
        public void RegisterUser(UserDTO userDto);
        public void UpdateUser(int id, UserDTO userDto);
        public string AuthenticateUser(UserDTO userDto);
        public Users GetUserById(int id);
    }
}
