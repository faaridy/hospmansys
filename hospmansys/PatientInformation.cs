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
    public partial class PatientInformation : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=patitent_regstration;uid=root;pwd=12345");

        public PatientInformation()
        {
            InitializeComponent();
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //when we click search button it call patient information 
            // if patient id is null it call all information
            //if we write patient id and click search button it call this id information
            try
            {
                connection.Open();
                if(textBox1.Text == "")
                {
                string cmdString = "select * from patient_information";

                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                }
                else
                {

                string cmdString = "select * from patient_information where patient_id='"+ textBox1.Text +"'";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                }
                connection.Close();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // update button update the patient status
            try
            {
                MessageBox.Show("You can only change patient status");
                connection.Open();
                string cmdString = "update patient_information set status = '"+ textBox8.Text +"' where patient_id='"+ textBox1.Text +"'";
                 MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                //and then outputs that person's information to the grid
                cmdString = "select * from patient_information where patient_id='" + textBox1.Text + "'";
                cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                connection.Close();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //we give patient id and this button delete that one
            try
            {
                connection.Open();
                string cmdString = "delete from patient_information where patient_id='" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                cmdString = "select * from patient_information";
                cmd = new MySqlCommand(cmdString, connection);
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
