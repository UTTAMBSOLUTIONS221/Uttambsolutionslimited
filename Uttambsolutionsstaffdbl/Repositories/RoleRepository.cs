using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Uttambsolutionsrole> Getuttambsolutionsroledata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Uttambsolutionsrole>("Usp_Getuttambsolutionsroledata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registeruttambsolutionsroledata(string JsonData)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonData);
                return connection.Query<Genericmodel>("Usp_Registeruttambsolutionsroledata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Uttambsolutionsrole Getuttambsolutionsroledatabyid(long Roleid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Roleid", Roleid);
                parameters.Add("@Systemroledata", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getuttambsolutionsroledatabyid", parameters, commandType: CommandType.StoredProcedure);
                string systemroledataJson = parameters.Get<string>("@Systemroledata");
                if (systemroledataJson != null)
                {
                    return JsonConvert.DeserializeObject<Uttambsolutionsrole>(systemroledataJson);
                }
                else
                {
                    return new Uttambsolutionsrole();
                }
            }
        }
    }
}
