using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Uttambsolutionsvehiclesdbl.Entities;
using Uttambsolutionsvehiclesdbl.Models;

namespace Uttambsolutionsvehiclesdbl.Repositories
{
    public class VehiclemodelRepository : BaseRepository, IVehiclemodelRepository
    {
        public VehiclemodelRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Uttambsolutionsvehiclemodel> Getuttambsolutionsvehiclemodeldata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Uttambsolutionsvehiclemodel>("Usp_Getuttambsolutionsvehiclemodeldata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registeruttambsolutionsvehiclemodeldata(string JsonData)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonData);
                return connection.Query<Genericmodel>("Usp_Registeruttambsolutionsvehiclemodeldata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Uttambsolutionsvehiclemodel Getuttambsolutionsvehiclemodeldatabyid(long Vehiclemodelid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Vehiclemodelid", Vehiclemodelid);
                return connection.Query<Uttambsolutionsvehiclemodel>("Usp_Getuttambsolutionsvehiclemodeldatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
