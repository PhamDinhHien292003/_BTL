using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BTL.Service
{
    internal class Create_Connection
    {
        public static SqlConnection createConnect(String connection)
        {
            return new SqlConnection(connection);
        }


        public SqlDataReader getQuery(String query, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader dr = cmd.ExecuteReader();
            return dr.HasRows ? dr : null;
        }


        public void setDb(String query, SqlConnection connection)
        {
            SqlDataReader dr = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close();

        }
    }
}

