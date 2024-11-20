using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Uttambsolutionsvehiclesdbl.Entities;
using Uttambsolutionsvehiclesdbl.Models;

namespace Uttambsolutionsvehiclesdbl.Repositories
{
    public class VehiclemakeRepository : BaseRepository, IVehiclemakeRepository
    {
        public VehiclemakeRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Uttambsolutionsvehiclemake> Getuttambsolutionsvehiclemakedata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Uttambsolutionsvehiclemake>("Usp_Getuttambsolutionsvehiclemakedata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registeruttambsolutionsvehiclemakedata(string JsonData)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonData);
                return connection.Query<Genericmodel>("Usp_Registeruttambsolutionsvehiclemakedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Uttambsolutionsvehiclemake Getuttambsolutionsvehiclemakedatabyid(long Vehiclemakeid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Vehiclemakeid", Vehiclemakeid);
                return connection.Query<Uttambsolutionsvehiclemake>("Usp_Getuttambsolutionsvehiclemakedatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
