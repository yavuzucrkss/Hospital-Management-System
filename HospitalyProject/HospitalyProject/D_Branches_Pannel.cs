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
    public partial class D_Branches_Pannel : Form
    {
        public D_Branches_Pannel()
        {
            InitializeComponent();
        }
        SQL_Connect connect = new SQL_Connect();
        private void D_Branches_Pannel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Brach", connect.Connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Connect().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add
            SqlCommand cmd = new SqlCommand("insert into Table_Brach (BranchName) values (@p2)", connect.Connect());
            cmd.Parameters.AddWithValue("@p1", IdTxtBox.Text);
            cmd.Parameters.AddWithValue("@p2", nametextbox.Text);
            cmd.ExecuteNonQuery();
            connect.Connect().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Brach", connect.Connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Connect().Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;
            IdTxtBox.Text = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            nametextbox.Text = dataGridView1.Rows[choosen].Cells[1].Value.ToString();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Brach", connect.Connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Connect().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            SqlCommand cmd = new SqlCommand("update Table_Brach set BranchName=@p2 where BrachId=@p3", connect.Connect());
            cmd.Parameters.AddWithValue("@p3", IdTxtBox.Text);
            cmd.Parameters.AddWithValue("@p2", nametextbox.Text);
            cmd.ExecuteNonQuery();
            connect.Connect().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Brach", connect.Connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Connect().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Table_Brach where BrachId=@p1", connect.Connect());
            cmd.Parameters.AddWithValue("@p1", IdTxtBox.Text);
            cmd.ExecuteNonQuery();
            connect.Connect().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Brach", connect.Connect());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Connect().Close();
        }
    }
}
