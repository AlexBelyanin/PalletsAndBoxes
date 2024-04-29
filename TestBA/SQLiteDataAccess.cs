using Dapper;
using System.Data;
using System.Data.SQLite;

namespace TestBA
{
    internal class SQLiteDataAccess
    {
        private static string ConnectionString = "Data Source=.\\PB.db;Version=3;";
        
        public static List<Box> LoadBoxes(int id)
        {
            using(IDbConnection conn = new SQLiteConnection(ConnectionString))
            {
                var output = conn.Query<Box>("select id,width,length,height,weight,expiration_date,production_date from Box where pallet_id = " + id.ToString());
                return output.ToList();
            }
        }

        public static List<Pallet> LoadPallets()
        {
            using (IDbConnection conn = new SQLiteConnection(ConnectionString))
            {
                var output = conn.Query<Pallet>("select * from Pallet");
                return output.ToList();
            }
        }
    }
}
