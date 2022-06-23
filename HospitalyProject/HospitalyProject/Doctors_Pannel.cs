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
    public partial class Doctors_Pannel : Form
    {
        public Doctors_Pannel()
        {
            InitializeComponent();
        }
        SQL_Connect connect = new SQL_Connect();
        int choosen;

        private void Doctors_Pannel_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Table_Doctor", connect.Connect());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            connect.Connect().Close();

            SqlCommand cmdBranch = new SqlCommand("Select BrachId ,BranchName from Table_Brach", connect.Connect());
            SqlDataReader dr1 = cmdBranch.ExecuteReader();
            while (dr1.Read())
            {
                BranchCmb.Items.Add(dr1[1].ToString());
            }
            connect.Connect().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Doctor

            SqlCommand command = new SqlCommand("insert into  Table_Doctor (DoctorName, DoctorSurname,DoctorBranch,DoctorTc,DoctorPassword) values(@p1,@p2,@p3,@p4,@p5)", connect.Connect());
            command.Parameters.AddWithValue("@p4",Tctxtbox.Text);
            command.Parameters.AddWithValue("@p1",nametextbox.Text);
            command.Parameters.AddWithValue("@p2",surnametextbox.Text);
            command.Parameters.AddWithValue("@p3",BranchCmb.Text);
            command.Parameters.AddWithValue("@p5",passwordtextbox.Text);
            command.ExecuteNonQuery();
            connect.Connect().Close();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Table_Doctor", connect.Connect());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             choosen = dataGridView1.SelectedCells[0].RowIndex;
            nametextbox.Text = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            surnametextbox.Text = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            BranchCmb.Text = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            Tctxtbox.Text = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            passwordtextbox.Text = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update

            SqlCommand cmd = new SqlCommand("update Table_Doctor set DoctorName=@p1,DoctorSurname=@p2,DoctorBranch=@p3,DoctorTc=@p4,DoctorPassword=@p5 where DoctorTc=@p6", connect.Connect());
            cmd.Parameters.AddWithValue("@p6", Tctxtbox.Text);
            cmd.Parameters.AddWithValue("@p1",nametextbox.Text);
            cmd.Parameters.AddWithValue("@p2",surnametextbox.Text);
            cmd.Parameters.AddWithValue("@p3",BranchCmb.Text);
            cmd.Parameters.AddWithValue("@p4",Tctxtbox.Text);
            cmd.Parameters.AddWithValue("@p5",passwordtextbox.Text);
            cmd.ExecuteNonQuery();
            connect.Connect().Close();
            MessageBox.Show("Doctor's Updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Table_Doctor", connect.Connect());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            SqlCommand cmd = new SqlCommand("Delete from Table_Doctor where DoctorTc=@p6", connect.Connect());
            cmd.Parameters.AddWithValue("@p6", Tctxtbox.Text);
            cmd.ExecuteNonQuery();
            connect.Connect().Close();
            MessageBox.Show("Doctor's Deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Table_Doctor", connect.Connect());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
    }
}
