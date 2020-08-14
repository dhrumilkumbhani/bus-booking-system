using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Speech.Synthesis;

namespace BusTicketSystem
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ADMIN\Documents\BusData.accdb;
                                Persist Security Info=False;";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            speech.Speak("Welcome to the portal");
            comboBox1.Items.Add("Ahmedabad");
            comboBox1.Items.Add("Surat");
            comboBox1.Items.Add("Vadodara");
            comboBox1.Items.Add("Jamnagar");
            comboBox3.Items.Add("AC");
            comboBox3.Items.Add("Non-AC");
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
            dateTimePicker1.MinDate = System.DateTime.Now;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] str = new string[5];
            string[] temp = null;
            temp = dateTimePicker1.Value.ToString().Split(' ');
            str[0] = comboBox1.SelectedItem.ToString();
            str[1] = comboBox2.SelectedItem.ToString();
            str[2] = comboBox3.SelectedItem.ToString();
            str[3] = temp[0];
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            command.CommandText = @"select * from BusInfo where BFrom='" + str[0] + "' and BTo='" + str[1] + "' and BusType='" + str[2] + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while(reader.Read())
            {
                count = count + 1;
            }
            reader.Close();
            conn.Close();
            if (count > 0)
            {
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                dateTimePicker1.Value = System.DateTime.Now;
                buslist obj = new buslist(str,count);
                obj.Show();
            }
            else
            {
                speech.Speak("Bus Not Found");
                MessageBox.Show("Bus Not Found...");
            }
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Value = System.DateTime.Now;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addbus add = new addbus();
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancellation obj = new cancellation();
            obj.Show();
        }
    }
}
