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
    public partial class SecretaryUpdate : Form
    {
        public SecretaryUpdate()
        {
            InitializeComponent();
        }

        SQL_Connect connect = new SQL_Connect();
        public string tcc;
        private void SecretaryUpdate_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = tcc;

            SqlCommand cmd1 = new SqlCommand("Select SecretaryNameSurname , SecretaryPassword from Table_Secretary where SecretaryTc=@p1", connect.Connect());
            cmd1.Parameters.AddWithValue("@p1", tcc);
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                NameTxtbox.Text = dr[0].ToString();
                PassTxtBox2.Text = dr[1].ToString();
            }
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("update Table_Secretary set SecretaryNameSurname = @p1 , SecretaryPassword = @p2 , SecretaryTc = @p3 where SecretaryTc=@p4 ", connect.Connect());
            cmd2.Parameters.AddWithValue("@p4",tcc);
            cmd2.Parameters.AddWithValue("@p1", NameTxtbox.Text);
            cmd2.Parameters.AddWithValue("@p2",PassTxtBox2.Text);
            cmd2.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            cmd2.ExecuteNonQuery();
            connect.Connect().Close();
            MessageBox.Show("Updated!");
        }
    }
}
