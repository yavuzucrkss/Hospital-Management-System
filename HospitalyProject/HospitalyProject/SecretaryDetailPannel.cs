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
    public partial class SecretaryDetailPannel : Form
    {
        public SecretaryDetailPannel()
        {
            InitializeComponent();
        }

        SQL_Connect connect = new SQL_Connect();
        public string Tc;
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void SecretaryDetailPannel_Load(object sender, EventArgs e)
        {
            tc_label.Text = Tc;

            SqlCommand cmd1 = new SqlCommand("Select SecretaryNameSurname from Table_Secretary where SecretaryTc = @p1", connect.Connect());
            cmd1.Parameters.AddWithValue("@p1", tc_label.Text);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read()) namelabel.Text = dr[0].ToString();
            connect.Connect().Close();
            //BrachList

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Brach", connect.Connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Connect().Close();
            //Doctors List

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select DoctorName , DoctorSurname, DoctorBranch From Table_Doctor", connect.Connect());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            connect.Connect().Close();

            //Branş ekleme
            SqlCommand cmdBranch = new SqlCommand("Select BrachId ,BranchName from Table_Brach", connect.Connect());
            SqlDataReader dr1 = cmdBranch.ExecuteReader();
            while (dr1.Read())
            {
                BranchCmb.Items.Add(dr1[1].ToString());
            }
            connect.Connect().Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SecretaryUpdate fr = new SecretaryUpdate();
            fr.tcc = tc_label.Text;
            fr.Show();
        }

        private void BranchButton(object sender, EventArgs e)
        {
            D_Branches_Pannel fr = new D_Branches_Pannel();
            fr.Show();
        }

        private void doctorsPannelButton(object sender, EventArgs e)
        {
            Doctors_Pannel fr = new Doctors_Pannel();
            fr.Show();
        }

        private void appointmentsbutton(object sender, EventArgs e)
        {
            Appointments fr = new Appointments();
            fr.Show();     
        }

        private void savebutton(object sender, EventArgs e)
        {
            SqlCommand cmdSave = new SqlCommand("insert into Table_Appointment (ApDate , ApTime, ApBranch, ApDoc) values (@p1,@p2,@p3,@p4)", connect.Connect());
            cmdSave.Parameters.AddWithValue("@p1",DateTextBox.Text);
            cmdSave.Parameters.AddWithValue("@p2",TimeTextbox.Text);
            cmdSave.Parameters.AddWithValue("@p3",BranchCmb.Text);
            cmdSave.Parameters.AddWithValue("@p4",DoctorCmb.Text);
           // cmdSave.Parameters.AddWithValue("@p5", true);
            cmdSave.ExecuteNonQuery();
            connect.Connect().Close();

            MessageBox.Show("Appointment Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BranchCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoctorCmb.Items.Clear();
            SqlCommand cmd3 = new SqlCommand("Select DoctorName,DoctorSurname from Table_Doctor where DoctorBranch = @p1", connect.Connect());
            cmd3.Parameters.AddWithValue("@p1", BranchCmb.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                DoctorCmb.Items.Add(dr3[0] + " " + dr3[1]);
            }
            connect.Connect().Close();
        }

        private void DoctorCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void anounsbutton(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("insert into Table_Anouns (Anouns) values (@p1)", connect.Connect());
            cmd1.Parameters.AddWithValue("@p1", AnounsTxt.Text);
            cmd1.ExecuteNonQuery();
            connect.Connect().Close();
            MessageBox.Show("Announs Created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            HospitalForm fr = new HospitalForm();
            fr.Show();
            this.Close();
        }
    }
}
