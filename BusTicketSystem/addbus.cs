using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Speech.Synthesis;

namespace BusTicketSystem
{
    public partial class addbus : Form
    {
        OleDbConnection conn = new OleDbConnection();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        public addbus()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ADMIN\Documents\BusData.accdb;
                                Persist Security Info=False;";
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string[] str = { "Ahmedabad", "Surat", "Vadodara", "Jamnagar" };
            for (int i = 0; i < str.Length; i++)
            {
                if (comboBox1.SelectedItem.ToString() != str[i])
                {
                    comboBox2.Items.Add(str[i]);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();   
        }

        private void addbus_Load_1(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Ahmedabad");
            comboBox1.Items.Add("Surat");
            comboBox1.Items.Add("Vadodara");
            comboBox1.Items.Add("Jamnagar");
            comboBox3.Items.Add("AC");
            comboBox3.Items.Add("Non-AC");
            comboBox4.Items.Add("7:00 AM");
            comboBox4.Items.Add("2:00 PM");
            comboBox4.Items.Add("10:00 PM");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            command.CommandText = @"select * from BusInfo where BusNumber='" + textBox1.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            reader.Close();
            if (count == 0)
            {
                command.CommandText = @"INSERT INTO BusInfo values('" + textBox1.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','"+ comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "')";
                command.ExecuteNonQuery();
                speech.Speak("Bus Added Successfully");
                MessageBox.Show("Bus Added Successfully");
            }
            else
            {
                speech.Speak("Bus Number is already exist");
                MessageBox.Show("Bus Number is already exist");
            }
            conn.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }
    }
}
