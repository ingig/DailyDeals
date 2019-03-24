using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DailyDeals.Logic
{
    public class Subscriptions
    {
        public bool Subscribe(string email)
        {
            int num = 0;
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=heimkauptilbod.database.windows.net;Initial Catalog=heimauptilbod;User ID=ingig;Password=9@m*SzJ5Dzy#Oq2LeE7!398I8@a5DPg37;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                sqlConnection.Open();
                num = SqlMapper.Execute((IDbConnection)sqlConnection, "insert into emails (email) values (@email)", (object)new
                {
                    email = email
                }, (IDbTransaction)null, new int?(), new CommandType?());
                sqlConnection.Close();
            }
            return num > 0;
        }

        public bool Unsubscribe(int id, string email)
        {
            int num = 0;
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=heimkauptilbod.database.windows.net;Initial Catalog=heimauptilbod;User ID=ingig;Password=9@m*SzJ5Dzy#Oq2LeE7!398I8@a5DPg37;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                sqlConnection.Open();
                num = SqlMapper.Execute((IDbConnection)sqlConnection, "DELETE FROM emails WHERE email=@email AND id=@id", (object)new
                {
                    email = email,
                    id = id
                }, (IDbTransaction)null, new int?(), new CommandType?());
                sqlConnection.Close();
            }
            return num > 0;
        }
    }
}
