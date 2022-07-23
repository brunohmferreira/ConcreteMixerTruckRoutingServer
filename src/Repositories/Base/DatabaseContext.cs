using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ConcreteMixerTruckRoutingServer.Repositories.Base
{
    public class DatabaseContext : DatabaseContextBase, IDatabaseContext
    {
        #region Constructor

        /// <summary>
        /// Constructor of the context of database
        /// </summary>
        public DatabaseContext(IConfiguration configuration) : base()
        {
            Connection = new SqlConnection(configuration.GetSection("Database:ConnectionString").Value);
        }

        #endregion
    }
}
