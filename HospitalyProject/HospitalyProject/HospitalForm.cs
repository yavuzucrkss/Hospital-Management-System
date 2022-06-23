using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalyProject
{
    public partial class HospitalForm : Form
    {
        public HospitalForm()
        {
            InitializeComponent();
        }

        private void buttondoctor(object sender, EventArgs e)
        {
            Doctor_SignPannel doctor = new Doctor_SignPannel();
            doctor.Show();
            this.Hide();
        }

        private void button_secretary(object sender, EventArgs e)
        {
            SecretaryLogin secretary = new SecretaryLogin();
            secretary.Show();
            this.Hide();
        }

        private void button_Patient(object sender, EventArgs e)
        {
            Patient_Form patient = new Patient_Form();
            patient.Show();
            this.Hide();
        }

    }
}
