using MySqlConnector;
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
    public partial class ViewPatientCheckout : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=patitent_regstration;uid=root;pwd=12345");
        public ViewPatientCheckout()
        {
            InitializeComponent();
        }

        private void ViewPatientCheckout_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //combine patient information and checkout and call database all info about patient
            try
            {
                connection.Open();
                string cmdString = "select * from patient_information join checkout using (patient_id) where patient_id='" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                connection.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
