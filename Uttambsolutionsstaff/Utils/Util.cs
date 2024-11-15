using Dapper;
using Microsoft.Data.SqlClient;

namespace Uttambsolutionsstaff
{
    public class Util
    {
        public static string ShareConnectionString(IConfiguration config)
        {
            // Retrieve the database connection details from environment variables
            var Dbhost = Environment.GetEnvironmentVariable("DB_HOST");
            var Dbname = Environment.GetEnvironmentVariable("DB_NAME");
            var Dbusername = Environment.GetEnvironmentVariable("DB_USERNAME");
            var Dbpassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            // Construct the connection string
            return $"Data Source={Dbhost};Database={Dbname};User Id={Dbusername};Password={Dbpassword};TrustServerCertificate=true";
        }

        private static void EnsureDatabaseAndTables(string Dbname, string connectionString)
        {
            // Connect to master database to check if the target database exists
            var masterConnectionString = connectionString.Replace($"Database={Dbname}", "Database=master");

            using (var connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();

                // Check if database exists
                var dbExistsQuery = "SELECT database_id FROM sys.databases WHERE Name = @DbName";
                var databaseId = connection.QueryFirstOrDefault<int?>(dbExistsQuery, new { DbName = Dbname });

                if (!databaseId.HasValue)
                {
                    // Create the database if it doesn't exist
                    connection.Execute($"CREATE DATABASE [{Dbname}]");
                }
            }

            // Connect to the target database to check and create tables if needed
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the target table exists and create it if it doesn’t
                var tableName = "YourTableName"; // Replace with your actual table name
                var tableExistsQuery = $@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName)
                    BEGIN
                        CREATE TABLE {tableName} (
                            Id INT PRIMARY KEY,
                            Name NVARCHAR(100)
                        )
                    END";
                connection.Execute(tableExistsQuery, new { TableName = tableName });
            }
        }

        public static void LogError(string userName, Exception ex, bool isError = true)
        {
            try
            {
                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");

                //---- Create Directory if it does not exist              
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                string logFile = Path.Combine(logDir, "ErrorLog.log");
                //--- Delete log if it more than 500Kb
                if (File.Exists(logFile))
                {
                    FileInfo fi = new FileInfo(logFile);
                    if ((fi.Length / 1000) > 500)
                        fi.Delete();
                }
                //--- Create stream writter
                StreamWriter stream = new StreamWriter(logFile, true);
                stream.WriteLine(string.Format("{0}|{1:dd-MMM-yyyy HH:mm:ss}|{2}|{3}",
                    isError ? "ERROR" : "INFOR",
                    DateTime.Now,
                    userName,
                    isError ? ex.ToString() : ex.Message));
                stream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string GetLogFile()
        {
            try
            {
                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");

                //---- Create Directory if it does not exist              
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                return Path.Combine(logDir, "ErrorLog.log");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public static UsermodelResponce GetCurrentUserData(IEnumerable<ClaimsIdentity> claims)
        //{
        //    // Find the claim that contains the user data
        //    var claim = claims.FirstOrDefault(u => u.IsAuthenticated && u.HasClaim(c => c.Type == "userData"))?.FindFirst("userData");

        //    // If the claim is not found or the value is null/empty, return null
        //    if (claim == null || string.IsNullOrEmpty(claim.Value))
        //        return null;

        //    // Deserialize the user data JSON to the UsermodelResponce object
        //    var userData = JsonConvert.DeserializeObject<UsermodelResponce>(claim.Value);

        //    // Perform any additional processing if needed
        //    return userData;
        //}
    }

    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";
        public string? AlertStyle { get; set; }
        public string? Message { get; set; }
        public bool Dismissable { get; set; }
        public string? IconClass { get; set; }
    }

    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }
}