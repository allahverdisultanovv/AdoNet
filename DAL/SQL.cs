using System.Data;
using System.Data.SqlClient;

namespace AdoNetClass.DAL
{
    internal class SQL
    {

        // "server=DESKTOP-78AQA66;database=AdoNetExampleDB;trusted_connection=true;integrated security=true;"
        private const string ConnectionString = "server=MSI;database=ADONETBP217;trusted_connection=true;integrated security=true;";
        private static SqlConnection connection = new SqlConnection(ConnectionString);


        public int ExecuteCommand(string command)
        {
            int result = 0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                connection.Close();
            }
            return dt;
        }
    }
}
