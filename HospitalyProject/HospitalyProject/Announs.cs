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
    public partial class Announs : Form
    {
        public Announs()
        {
            InitializeComponent();
        }
        SQL_Connect connect = new SQL_Connect();
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;
            MessageBox.Show(dataGridView1.Rows[choosen].Cells[1].Value.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Announs_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From Table_Anouns", connect.Connect());
            sqlDataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;



        }
    }
}
