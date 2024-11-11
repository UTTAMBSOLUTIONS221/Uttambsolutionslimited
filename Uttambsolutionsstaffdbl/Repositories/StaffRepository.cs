using Dapper;
using System.Data;
using System.Data.SqlClient;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public class StaffRepository : BaseRepository, IStaffRepository
    {
        public StaffRepository(string connectionString) : base(connectionString)
        {
        }
        public IEnumerable<Uttambsolutionsstaffs> Getuttambsolutionsstaffdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Uttambsolutionsstaffs>("Usp_Getuttambsolutionsstaffdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registeruttambsolutionsstaffdata(string JsonData)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonData);
                return connection.Query<Genericmodel>("Usp_Registeruttambsolutionsstaffdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Uttambsolutionsstaffs Getuttambsolutionsstaffdatabyid(long Staffid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Staffid", Staffid);
                return connection.Query<Uttambsolutionsstaffs>("Usp_Getuttambsolutionsstaffdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
