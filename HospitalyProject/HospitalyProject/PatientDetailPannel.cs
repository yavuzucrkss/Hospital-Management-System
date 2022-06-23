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
    public partial class PatientDetailPannel : Form
    {
        public PatientDetailPannel()
        {
            InitializeComponent();
        }
        public string tc;

        SQL_Connect connect = new SQL_Connect();
        int choosen;
        private void PatientDetailPannel_Load(object sender, EventArgs e)
        {
            tc_label.Text = tc; //Add Tc

             // Add Name & Surname
            SqlCommand cmd1 = new SqlCommand("Select PatientName, PatientSurname From Table_Patient where PatientTc = @p1", connect.Connect());
            cmd1.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                namelabel.Text = dr1[0].ToString();
                surnamelabel.Text = dr1[1].ToString();
            }
            connect.Connect().Close();

            //Add Appointment List
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Table_Appointment where PatientTC ='" + tc + "' and ApState= 1", connect.Connect());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            connect.Connect().Close();

            // Add Branches

            SqlCommand cmd2 = new SqlCommand("Select BranchName From Table_Brach", connect.Connect());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {

                comboBox1.Items.Add(dr2[0]);
            }
            connect.Connect().Close();

          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Add Doctors
            comboBox2.Items.Clear();
            SqlCommand cmd3 = new SqlCommand("Select DoctorName,DoctorSurname from Table_Doctor where DoctorBranch = @p1", connect.Connect());
            cmd3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3[0] + " " + dr3[1]);
            }
            connect.Connect().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            P_updatepannel fr = new P_updatepannel();
            fr.tc = tc_label.Text;
            fr.Show();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Appointment where ApBranch='" + comboBox1.Text + "' and ApDoc='" + comboBox2.Text + "' and  ApState = 0", connect.Connect());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //TakeAppointment
            SqlCommand cmd = new SqlCommand("update Table_Appointment set ApState=1 , PatientTc=@p1, PatientComp=@p2 where ApId=@p3", connect.Connect());
            cmd.Parameters.AddWithValue("@p1", tc_label.Text);
            cmd.Parameters.AddWithValue("@p2", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@p3", IdTxt.Text);
            cmd.ExecuteNonQuery();
            connect.Connect().Close();

            MessageBox.Show("Taken Appointment", "Info");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Appointment where ApBranch='" + comboBox1.Text + "' and ApDoc='" + comboBox2.Text + "' and  ApState = 0", connect.Connect());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Table_Appointment where PatientTC ='" + tc + "' and ApState= 1" , connect.Connect());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            connect.Connect().Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            choosen = dataGridView2.SelectedCells[0].RowIndex;
            IdTxt.Text = dataGridView2.Rows[choosen].Cells[0].Value.ToString();
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            HospitalForm fr = new HospitalForm();
            fr.Show();
            this.Close();
        }
    }
}
