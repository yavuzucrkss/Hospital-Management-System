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
    public partial class DoctorDetailForm : Form
    {
        public DoctorDetailForm()
        {
            InitializeComponent();
        }
        public string tc;
        SQL_Connect connect = new SQL_Connect();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DupdatePannel fr = new DupdatePannel();
            fr.tc = tc;
            fr.Show();
        }

        private void announsbutton(object sender, EventArgs e)
        {
            Announs fr = new Announs();
            fr.Show();
        }

        private void DoctorDetailForm_Load(object sender, EventArgs e)
        {
            tc_label.Text = tc;
            SqlCommand cmd1 = new SqlCommand("Select DoctorName , DoctorSurname From Table_Doctor where DoctorTc=@p1", connect.Connect());
            cmd1.Parameters.AddWithValue("@p1", tc_label.Text);
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                namelabel.Text = dr[0].ToString();
                surnamelabel.Text = dr[1].ToString();
            }
         


            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Table_Appointment where ApDoc='" + namelabel.Text +" " + surnamelabel.Text +"'", connect.Connect());
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void QuitButton(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[choosen].Cells[7].Value.ToString();

            SqlCommand cmd = new SqlCommand("Select ApComp from Table_Appointment ApId=@p1", connect.Connect());
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            HospitalForm fr = new HospitalForm();
            fr.Show();
            this.Close();
        }
    }
}
