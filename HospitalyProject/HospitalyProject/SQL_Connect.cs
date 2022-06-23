using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HospitalyProject
{
    class SQL_Connect
    {
        public SqlConnection Connect() 
        {
            SqlConnection connect = new SqlConnection("Data Source=YAVUZ;Initial Catalog=HospitalProject;Integrated Security=True");
            connect.Open();
            return connect;
        }
    }
}
