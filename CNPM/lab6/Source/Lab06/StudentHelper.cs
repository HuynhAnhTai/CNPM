using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    public class StudentHelper
    {
        
        private SqlConnection conn;
        public StudentHelper()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-JRNC7GN\SQLEXPRESS;Initial Catalog=Lab06;Integrated Security=True");
            conn.Open();
        }

        public int ExcuteNonQuery(String sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            int rows = cmd.ExecuteNonQuery();

            return rows;
        }
    }
}
