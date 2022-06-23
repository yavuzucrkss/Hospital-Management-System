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
    public partial class SecretaryLogin : Form
    {
        public SecretaryLogin()
        {
            InitializeComponent();
        }
        SQL_Connect connect = new SQL_Connect();

        private void SecrateryLoginButton(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select * From Table_Secretary where SecretaryTc = @p1 and SecretaryPassword = @p2", connect.Connect());
            cmd1.Parameters.AddWithValue("@p1", TcTxt.Text);
            cmd1.Parameters.AddWithValue("@p2", PassTxt.Text);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                SecretaryDetailPannel fr = new SecretaryDetailPannel();
                fr.Tc = TcTxt.Text;
                fr.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Wrong Password", "Attention!");
            }
        }
    }
}
