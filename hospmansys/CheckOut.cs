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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hospmansys
{

    public partial class CheckOut : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=patitent_regstration;uid=root;pwd=12345");

        public CheckOut()
        {
            InitializeComponent();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this button add checkout resluts in database
            try
            {
                connection.Open();
                string cmdString = "insert into checkout(patient_id,disease,date_in,date_out,additional_information,medicine_price,total) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Stored Successfully");
                connection.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            //reset button used for clear all text box
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
