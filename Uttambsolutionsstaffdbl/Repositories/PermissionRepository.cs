using Dapper;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;
using System.Data;
using System.Data.SqlClient;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public class PermissionRepository : BaseRepository, IPermissionRepository
    {
        public PermissionRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Uttambsolutionspermission> Getuttambsolutionspermissiondata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Uttambsolutionspermission>("Usp_Getuttambsolutionspermissiondata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registeruttambsolutionspermissiondata(string JsonData)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonData);
                return connection.Query<Genericmodel>("Usp_Registeruttambsolutionspermissiondata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Uttambsolutionspermission Getuttambsolutionspermissiondatabyid(long Permissionid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Permissionid", Permissionid);
                return connection.Query<Uttambsolutionspermission>("Usp_Getuttambsolutionspermissiondatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
