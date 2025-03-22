using System.Data;

namespace GrupparbeteAuktion.Data.Interfaces
{
    public interface IAuctionDBContext
    {
        public IDbConnection GetConnection();
    }
}
