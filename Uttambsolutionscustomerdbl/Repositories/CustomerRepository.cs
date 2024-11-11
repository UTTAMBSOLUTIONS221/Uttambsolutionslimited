using Dapper;
using System.Data;
using System.Data.SqlClient;
using Uttambsolutionscustomerdbl.Entities;
using Uttambsolutionscustomerdbl.Models;

namespace Uttambsolutionscustomerdbl.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }
        public IEnumerable<Uttambsolutionscustomers> Getuttambsolutionscustomerdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Uttambsolutionscustomers>("Usp_Getuttambsolutionscustomerdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registeruttambsolutionscustomerdata(string JsonData)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonData);
                return connection.Query<Genericmodel>("Usp_Registeruttambsolutionscustomerdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Uttambsolutionscustomers Getuttambsolutionscustomerdatabyid(long Customerid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Customerid", Customerid);
                return connection.Query<Uttambsolutionscustomers>("Usp_Getuttambsolutionscustomerdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
