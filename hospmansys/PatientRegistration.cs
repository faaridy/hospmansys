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
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hospmansys
{
    public partial class PatientRegistration : Form
    {
        // Connection to database
        MySqlConnection connection = new MySqlConnection("server=localhost;database=patitent_regstration;uid=root;pwd=12345");

        public PatientRegistration()
        {
            InitializeComponent();
        }
        
        private void PatientRegistration_Load(object sender, EventArgs e)
        {


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                //write query 
                string cmdString = "insert into patient_information(patient_id,name,gender,age,date,contact,address,disease,status,building,room_number) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
                //send query in database
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Stored Successfully");

                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
            
        }

        

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            comboBox1.Text = "";
        }
    }
}
