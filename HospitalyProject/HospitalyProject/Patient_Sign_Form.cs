using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalyProject
{
    public partial class Patient_Sign_Form : Form
    {
        public Patient_Sign_Form()
        {
            InitializeComponent();
        }
        SQL_Connect connect = new SQL_Connect();
        private void signbutton_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Table_Patient (PatientName,PatientSurname,PatientTc,PatientTel,PatientGender,PatientPassword) values (@p1,@p2,@p3,@p4,@p5,@p6)", connect.Connect());
            command.Parameters.AddWithValue("@p1", nametextbox.Text);
            command.Parameters.AddWithValue("@p2", surnametextbox.Text);
            command.Parameters.AddWithValue("@p3", Tctxtbox.Text);
            command.Parameters.AddWithValue("@p4", phonetextbox.Text);
            command.Parameters.AddWithValue("@p5", genderlabel.Text);
            command.Parameters.AddWithValue("@p6", passwordtextbox.Text);
            command.ExecuteNonQuery();
            connect.Connect().Close();
            MessageBox.Show("Success!");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                genderlabel.Text = "Man";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                genderlabel.Text = "Female";
            }
        }
    }
}
