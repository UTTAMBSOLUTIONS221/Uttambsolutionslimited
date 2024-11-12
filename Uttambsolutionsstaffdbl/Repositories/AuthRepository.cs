using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(string connectionString) : base(connectionString)
        {
        }
        public Uttambsolutionsstaffresponce Validateuttambsolutionsstaffdata(string Username)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", Username);
                return connection.Query<Uttambsolutionsstaffresponce>("Usp_Validateuttambsolutionsstaffdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
