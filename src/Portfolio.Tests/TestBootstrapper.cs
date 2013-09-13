using System.Data;
using System.Data.SqlClient;

namespace Portfolio.Tests
{
    public class TestBootstrapper
    {
        public static IDbConnection ConnectToDatabase()
        {
            return new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Portfolio_test;Integrated Security=true;");
        }
    }
}
