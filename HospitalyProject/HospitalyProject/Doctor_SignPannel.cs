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
    public partial class Doctor_SignPannel : Form
    {
        public Doctor_SignPannel()
        {
            InitializeComponent();
        }
        SQL_Connect connect = new SQL_Connect();

        private void LoginBttn(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Table_Doctor where DoctorTc=@p1 and DoctorPassword=@p2", connect.Connect());
            cmd.Parameters.AddWithValue("@p1", TcTxt.Text);
            cmd.Parameters.AddWithValue("@p2", PassTxt.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DoctorDetailForm fr = new DoctorDetailForm();
                fr.tc = TcTxt.Text;
                fr.Show();              
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Pass or Tc", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connect.Connect().Close();
        }
    }
}
