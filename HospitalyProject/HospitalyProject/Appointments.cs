using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HospitalyProject
{
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
        }
        SQL_Connect connect =new SQL_Connect();
       
        private void Appointments_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Appointment", connect.Connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Connect().Close();
        }

       
    }
}
