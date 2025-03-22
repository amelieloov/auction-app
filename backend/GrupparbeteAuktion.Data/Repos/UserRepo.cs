using Dapper;
using GrupparbeteAuktion.Data.Interfaces;
using GrupparbeteAuktion.Domain.Models;
using System.Data;

namespace GrupparbeteAuktion.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly IAuctionDBContext _dbContext;

        public UserRepo(IAuctionDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(string UserName, string Password)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName);
                parameters.Add("@Password", Password);

                db.Execute("AddUser", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public void UpdateUser(int userID, int userName, int password)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userID);
                parameters.Add("@UserName", userName);
                parameters.Add("@Password", password);

                db.Execute("UpdateUser", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public void DeleteUser(int userID)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userID);
               
                db.Execute("DeleteUser", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public Users GetUser(int userID)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                db.Open();

                return db.Query<Users>("GetUser", commandType: CommandType.StoredProcedure).SingleOrDefault();

            }

        }
    }
}
