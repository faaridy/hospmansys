using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospmansys
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        
        //create object for each menu and call ShowDialog method
        private void patientRegistration_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           PatientRegistration obj = new PatientRegistration();
            obj.ShowDialog();
        }

        private void patientInformation_toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PatientInformation obj1 = new PatientInformation();
            obj1.ShowDialog();
        }

        private void checkout_toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CheckOut obj2 = new CheckOut();
            obj2.ShowDialog();
        }

        private void addStaff_toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AddStaff obj4 = new AddStaff();
            obj4.ShowDialog();
        }

        private void viewPatientCheckout_toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ViewPatientCheckout obj5 = new ViewPatientCheckout();
            obj5.ShowDialog();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
