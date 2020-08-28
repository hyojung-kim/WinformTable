using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//sql connection
using System.Data;//DataSet 쓸때 필요

namespace WinformTable
{
    public class DB
    {
        public SqlConnection dbConnect()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Server=localhost; database=COMDB; uid=sa; pwd=sa";
            return conn;
        }

        public DataSet GetData(String szQuery)
        {
            SqlConnection conn = dbConnect();

            SqlDataAdapter adapter = new SqlDataAdapter(szQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

    }

}
