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
    public partial class DupdatePannel : Form
    {
        public DupdatePannel()
        {
            InitializeComponent();
        }
        SQL_Connect connect = new SQL_Connect();
        public string tc;
        private void DupdatePannel_Load(object sender, EventArgs e)
        {
            Tctxtbox.Text = tc;
            SqlCommand cmd = new SqlCommand("Select DoctorName , DoctorSurname, DoctorBranch,DoctorPassword from Table_Doctor where DoctorTc=@p1", connect.Connect());
            cmd.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                nametextbox.Text = dataReader[0].ToString();
                surnametextbox.Text = dataReader[1].ToString();
                BranchCmb.Text = dataReader[2].ToString();
                passwordtextbox.Text = dataReader[3].ToString();
            }

            connect.Connect().Close();

            //BranchCmb Adding
            SqlCommand cmd1 = new SqlCommand("Select BranchName from Table_Brach", connect.Connect());
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                BranchCmb.Items.Add(dr[0].ToString());
            }
            connect.Connect().Close();
        }

        private void UpdateButton(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Table_Doctor set DoctorTc=@p1,DoctorName=@p2,DoctorSurname=@p3,DoctorBranch=@p4,DoctorPassword=@p5 where DoctorTc=@p6", connect.Connect());
            cmd.Parameters.AddWithValue("@p6",tc);
            cmd.Parameters.AddWithValue("@p2",nametextbox.Text);
            cmd.Parameters.AddWithValue("@p1",Tctxtbox.Text);
            cmd.Parameters.AddWithValue("@p3",surnametextbox.Text);
            cmd.Parameters.AddWithValue("@p4",BranchCmb.Text);
            cmd.Parameters.AddWithValue("@p5",passwordtextbox.Text);
            cmd.ExecuteNonQuery();
            connect.Connect().Close();

            MessageBox.Show("Updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
