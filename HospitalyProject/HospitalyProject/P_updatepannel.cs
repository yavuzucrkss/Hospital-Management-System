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
    public partial class P_updatepannel : Form
    {
        public P_updatepannel()
        {
            InitializeComponent();
        }
        public string tc;

        SQL_Connect connect = new SQL_Connect();
        private void P_updatepannel_Load(object sender, EventArgs e)
        {
            Tctxtbox.Text = tc;
            SqlCommand cmd1 = new SqlCommand("Select * From Table_Patient where PatientTc= @p1",connect.Connect());
            cmd1.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                nametextbox.Text = dr[1].ToString();
                surnametextbox.Text = dr[2].ToString();
                phonetextbox.Text = dr[4].ToString();
                passwordtextbox.Text = dr[5].ToString();
                genderLabel.Text = dr[6].ToString();
                if (genderLabel.Text == "Male") radioButton1.Checked = true;
                if (genderLabel.Text == "Female") radioButton2.Checked = true;
            }
            connect.Connect().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 =new SqlCommand("update Table_Patient set PatientName = @p1,PatientSurname=@p2,PatientTc=@p3,PatientTel=@p4, PatientPassword= @p5 where PatientTc = @p6", connect.Connect());
            cmd2.Parameters.AddWithValue("@p6", tc);
            cmd2.Parameters.AddWithValue("@p1", nametextbox.Text);
            cmd2.Parameters.AddWithValue("@p2", surnametextbox.Text);
            cmd2.Parameters.AddWithValue("@p3", Tctxtbox.Text);
            cmd2.Parameters.AddWithValue("@p4", phonetextbox.Text);
            cmd2.Parameters.AddWithValue("@p5", passwordtextbox.Text);
            cmd2.ExecuteNonQuery();
            connect.Connect().Close();

            MessageBox.Show("Updated Information", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
