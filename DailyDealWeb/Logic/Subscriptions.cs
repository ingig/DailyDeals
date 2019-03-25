using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DailyDeals.Logic
{
    public class Subscriptions
    {
        public bool Subscribe(string email)
        {
            int num = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                sqlConnection.Open();
                num = SqlMapper.Execute((IDbConnection)sqlConnection, "insert into emails (email) values (@email)", (object)new
                {
                    email
                });
                sqlConnection.Close();
            }
            return num > 0;
        }

        public bool Unsubscribe(int id, string email)
        {
            int num = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                sqlConnection.Open();
                num = SqlMapper.Execute((IDbConnection)sqlConnection, "DELETE FROM emails WHERE email=@email AND id=@id", (object)new
                {
                    email,
                    id
                });
                sqlConnection.Close();
            }
            return num > 0;
        }
    }
}
