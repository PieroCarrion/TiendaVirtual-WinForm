using System.Data.SqlClient;
namespace Datos {
    public class Database {
        private SqlConnection conn;
        public SqlConnection conectaDB() {
            try {
                conn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = TiendaVirtualDB_EB; Integrated Security = True");
                conn.Open();
                return conn;
            } catch(SqlException ex) {
                return null;
            }
        }
        public void desconectaDB() {
            conn.Close();
        }
    }
}
