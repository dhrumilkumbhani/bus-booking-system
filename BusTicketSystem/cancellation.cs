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
    public partial class cancellation : Form
    {
        OleDbConnection conn = new OleDbConnection();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        public cancellation()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ADMIN\Documents\BusData.accdb;
                                Persist Security Info=False;";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Text.ToString());
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            command.CommandText = @"select TicketID from PassengerInfo where TicketID=" + i;
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            reader.Close();
            if (count == 1)
            {
                
                command.CommandText = @"delete from PassengerInfo where TicketID=" + i;
                command.ExecuteNonQuery();
                command.CommandText = @"delete from ReserveInfo where TicketID=" + i;
                command.ExecuteNonQuery();
                speech.Speak("Ride Successfully canceled");
                //MessageBox.Show("Ride Successfully canceled");
            }
            else
            {
                speech.Speak("Invalid Ticket ID");
                MessageBox.Show("Invalid Ticket ID");
            }
            
            conn.Close();
            textBox1.Text = "";
        }
    }
}
