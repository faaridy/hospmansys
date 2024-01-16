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
    public partial class AddStaff : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=patitent_regstration;uid=root;pwd=12345");

        public AddStaff()
        {
            InitializeComponent();
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //add staff in database
            try
            {
                connection.Open();
                string cmdString = "insert into staff(staff_id,name,gender,position,salary,contact,address) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Stored Successfully");
                cmdString = "select * from staff";
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search staff in database if staff id null it call all information
            //if we write staff id and click button it call thats it information
            try
            {
                connection.Open();
                if (textBox1.Text == "")
                {
                    string cmdString = "select * from staff";

                    MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                else
                {

                    string cmdString = "select * from staff where staff_id='" + textBox1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }


                connection.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //update staff salary and show thats it staff
            try
            {
                MessageBox.Show("You can only change staff salary");
                connection.Open();
                string cmdString = "update staff set salary = '" + textBox4.Text + "' where staff_id='" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                cmdString = "select * from staff where staff_id='" + textBox1.Text + "'";
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
        private void btnReset_Click(object sender, EventArgs e)
        {
            //clear all text box
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            dataGridView1.DataSource = "";
        }
    }
}
