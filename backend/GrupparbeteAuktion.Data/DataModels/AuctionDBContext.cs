using GrupparbeteAuktion.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GrupparbeteAuktion.Data.DataModels
{
    public class AuctionDBContext : IAuctionDBContext
    {
        private readonly string _connString;

        public AuctionDBContext(IConfiguration config)
        {
            _connString = config.GetConnectionString("AuctionDB"); // <-- Insert connection string here
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connString);
        }
    }
}
