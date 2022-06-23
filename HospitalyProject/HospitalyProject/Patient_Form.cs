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
    public partial class Patient_Form : Form
    {
        public Patient_Form()
        {
            InitializeComponent();
        }
        SQL_Connect sQL = new SQL_Connect();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Patient_Sign_Form patient_Sign = new Patient_Sign_Form();
            patient_Sign.Show();
        }

        private void loginbutton(object sender, EventArgs e)
        {
            
            SqlCommand command = new SqlCommand("Select * From Table_Patient Where PatientTc= @p1 and PatientPassword= @p2", sQL.Connect());
            command.Parameters.AddWithValue("@p1", TcTxt.Text);
            command.Parameters.AddWithValue("@p2", PassTxt.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                PatientDetailPannel fr = new PatientDetailPannel();
                fr.tc = TcTxt.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password or TC");
            }
            sQL.Connect().Close();
        }

       
    }
}
