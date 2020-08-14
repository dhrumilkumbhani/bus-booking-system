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
    public partial class buslist : Form
    {
        OleDbConnection conn = new OleDbConnection();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        string[] s = new string[4];
        int c;
        string seat = ",";
        string Busno;
        //int flag = 0;
        string[] revseat = new string[31];
        public buslist(string[] str,int count)
        {
            InitializeComponent();
            for(int i =0;i<4;i++)
            {
                s[i] = str[i];
            }
            c = count;
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ADMIN\Documents\BusData.accdb;
                                Persist Security Info=False;";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = System.Drawing.Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = System.Drawing.Color.Transparent;
        }
        
        private void buslist_Load(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            command.CommandText = @"select BusNumber,DepartTime from BusInfo where BFrom='" + s[0] + "' and BTo='" + s[1] + "' and BusType='" + s[2] + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0, j = 0;
            string[,] str = new string[3, 3];
            while(reader.Read())
            {
                j = 0;
                str[i, j] = reader["BusNumber"].ToString();
                j = 1;
                str[i, j] = reader["DepartTime"].ToString();
                i++;
            }
            button1.Text = str[0, 0] + "\nTime = " + str[0, 1];
            button3.Text = str[1, 0] + "\nTime = " + str[1, 1];
            button4.Text = str[2, 0] + "\nTime = " + str[2, 1];
            reader.Close();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setseat();
            Busno = button3.Text.ToString();
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            string[] temp = null;
            temp = button3.Text.ToString().Split('\n');
            temp[1] = temp[1].Substring(7);
            //MessageBox.Show(temp[1]);
            command.CommandText = @"select ReserveSeat from ReserveInfo where BusNumber='" + temp[0] + "' and DepartDate='" + s[3] + "'";
            OleDbDataReader reader = command.ExecuteReader();
            string str;
            //MessageBox.Show(i.ToString());
            int k = 0;
            int len;
            while (reader.Read())
            {
                string[] str2 = null;
                str = reader["ReserveSeat"].ToString();
                str2 = str.Split(',');
                len = str2.Length;
                for(int j=0;j<len;k++,j++)
                {
                    revseat[k] = str2[j];
                }
            }
            revseat[k] = null;
            conn.Close();
            reserveseatset();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = System.Drawing.Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = System.Drawing.Color.Transparent;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.Transparent;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            
                seat = seat + "3,";
                //flag++;
                btn_3.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            
                seat = seat + "2,";
                //flag++;
                btn_2.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
                seat = seat + "1,";
                //flag++;
                btn_1.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "4,";
                //flag++;
                btn_4.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "5,";
                //flag++;
                btn_5.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "6,";
                //flag++;
                btn_6.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "7,";
                //flag++;
                btn_7.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "8,";
                //flag++;
                btn_8.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "9,";
                //flag++;
                btn_9.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "10,";
                //flag++;
                btn_10.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "11,";
                //flag++;
                btn_11.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "12,";
                //flag++;
                btn_12.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "13,";
                //flag++;
                btn_13.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "14,";
                //flag++;
                btn_14.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "15,";
                //flag++;
                btn_15.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_16_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "16,";
                //flag++;
                btn_16.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_17_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "17,";
                //flag++;
                btn_17.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_18_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "18,";
                //flag++;
                btn_18.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_19_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "19,";
                //flag++;
                btn_19.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_20_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "20,";
                //flag++;
                btn_20.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_21_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "21,";
                //flag++;
                btn_21.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_22_Click(object sender, EventArgs e)
        {

            btn_book.Enabled = true;
            seat = seat + "22,";
                //flag++;
                btn_22.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_23_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "23,";
                //flag++;
                btn_23.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_24_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "24,";
                //flag++;
                btn_24.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_25_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "25,";
                //flag++;
                btn_25.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_26_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "26,";
                //flag++;
                btn_26.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_27_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "27,";
                //flag++;
                btn_27.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_28_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "28,";
                //flag++;
                btn_28.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_29_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "29,";
                //flag++;
                btn_29.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_30_Click(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
            seat = seat + "30,";
                //flag++;
                btn_30.BackColor = System.Drawing.Color.Gray;
            
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            int len = seat.Length;
            seat = seat.Substring(1, len - 2);
            MessageBox.Show(seat);
            string[] temp = null;
            temp = Busno.Split('\n');
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            command.CommandText = @"insert into PassengerInfo(PName,PMoNo,BusNumber) values('" + txt_name.Text.ToString() + "','" + txt_mobile.Text.ToString() + "','" + temp[0] + "')";
            command.ExecuteNonQuery();
            len = temp[1].Length;
            temp[1] = temp[1].Substring(7, len - 7);
            //MessageBox.Show(temp[0]);
            //MessageBox.Show(temp[1]);
            command.CommandText = @"insert into ReserveInfo(BusNumber,DepartDate,DepartTime,ReserveSeat) values('" + temp[0] + "','" + s[3] + "','" + temp[1] + "','" + seat + "')";
            command.ExecuteNonQuery();
            conn.Close();
            speech.Speak("Ticket Booked Successfully");
            //MessageBox.Show("Ticket Booked Successfully");
            txt_name.Text = "";
            txt_mobile.Text = "";
            Print pr = new Print();
            pr.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setseat();
            Busno = button1.Text.ToString();
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            string[] temp = null;
            temp = button1.Text.ToString().Split('\n');
            temp[1] = temp[1].Substring(7);
            //MessageBox.Show(temp[1]);
            command.CommandText = @"select ReserveSeat from ReserveInfo where BusNumber='" + temp[0] + "' and DepartDate='" + s[3] + "'";
            OleDbDataReader reader = command.ExecuteReader();
            string str;
            //MessageBox.Show(i.ToString());
            int k = 0;
            int len;
            while (reader.Read())
            {
                string[] str2 = null;
                str = reader["ReserveSeat"].ToString();
                str2 = str.Split(',');
                len = str2.Length;
                for (int j = 0; j < len; k++, j++)
                {
                    revseat[k] = str2[j];
                }
            }
            revseat[k] = null;
            conn.Close();
            reserveseatset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setseat();
            Busno = button4.Text.ToString();
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            string[] temp = null;
            temp = button4.Text.ToString().Split('\n');
            temp[1] = temp[1].Substring(7);
            //MessageBox.Show(temp[1]);
            command.CommandText = @"select ReserveSeat from ReserveInfo where BusNumber='" + temp[0] + "' and DepartDate='" + s[3] + "'";
            OleDbDataReader reader = command.ExecuteReader();
            string str;
            //MessageBox.Show(i.ToString());
            int k = 0;
            int len;
            while (reader.Read())
            {
                string[] str2 = null;
                str = reader["ReserveSeat"].ToString();
                str2 = str.Split(',');
                len = str2.Length;
                for (int j = 0; j < len; k++, j++)
                {
                    revseat[k] = str2[j];
                }
            }
            revseat[k] = null;
            conn.Close();
            reserveseatset();
        }

        public void reserveseatset()
        {
            for(int i=0;revseat[i]!=null;i++)
            {
                switch(revseat[i])
                {
                    case "1":
                        btn_1.Enabled = false;
                        btn_1.BackColor = System.Drawing.Color.Red;
                        break;

                    case "2":
                        btn_2.Enabled = false;
                        btn_2.BackColor = System.Drawing.Color.Red;
                        break;

                    case "3":
                        btn_3.Enabled = false;
                        btn_3.BackColor = System.Drawing.Color.Red;
                        break;

                    case "4":
                        btn_4.Enabled = false;
                        btn_4.BackColor = System.Drawing.Color.Red;
                        break;

                    case "5":
                        btn_5.Enabled = false;
                        btn_5.BackColor = System.Drawing.Color.Red;
                        break;

                    case "6":
                        btn_6.Enabled = false;
                        btn_6.BackColor = System.Drawing.Color.Red;
                        break;

                    case "7":
                        btn_7.Enabled = false;
                        btn_7.BackColor = System.Drawing.Color.Red;
                        break;

                    case "8":
                        btn_8.Enabled = false;
                        btn_8.BackColor = System.Drawing.Color.Red;
                        break;

                    case "9":
                        btn_9.Enabled = false;
                        btn_9.BackColor = System.Drawing.Color.Red;
                        break;

                    case "10":
                        btn_10.Enabled = false;
                        btn_10.BackColor = System.Drawing.Color.Red;
                        break;

                    case "11":
                        btn_11.Enabled = false;
                        btn_11.BackColor = System.Drawing.Color.Red;
                        break;

                    case "12":
                        btn_12.Enabled = false;
                        btn_12.BackColor = System.Drawing.Color.Red;
                        break;

                    case "13":
                        btn_13.Enabled = false;
                        btn_13.BackColor = System.Drawing.Color.Red;
                        break;

                    case "14":
                        btn_14.Enabled = false;
                        btn_14.BackColor = System.Drawing.Color.Red;
                        break;

                    case "15":
                        btn_15.Enabled = false;
                        btn_15.BackColor = System.Drawing.Color.Red;
                        break;

                    case "16":
                        btn_16.Enabled = false;
                        btn_16.BackColor = System.Drawing.Color.Red;
                        break;

                    case "17":
                        btn_17.Enabled = false;
                        btn_17.BackColor = System.Drawing.Color.Red;
                        break;

                    case "18":
                        btn_18.Enabled = false;
                        btn_18.BackColor = System.Drawing.Color.Red;
                        break;

                    case "19":
                        btn_19.Enabled = false;
                        btn_19.BackColor = System.Drawing.Color.Red;
                        break;

                    case "20":
                        btn_20.Enabled = false;
                        btn_20.BackColor = System.Drawing.Color.Red;
                        break;

                    case "21":
                        btn_21.Enabled = false;
                        btn_21.BackColor = System.Drawing.Color.Red;
                        break;

                    case "22":
                        btn_22.Enabled = false;
                        btn_22.BackColor = System.Drawing.Color.Red;
                        break;

                    case "23":
                        btn_23.Enabled = false;
                        btn_23.BackColor = System.Drawing.Color.Red;
                        break;

                    case "24":
                        btn_24.Enabled = false;
                        btn_24.BackColor = System.Drawing.Color.Red;
                        break;

                    case "25":
                        btn_25.Enabled = false;
                        btn_25.BackColor = System.Drawing.Color.Red;
                        break;

                    case "26":
                        btn_26.Enabled = false;
                        btn_26.BackColor = System.Drawing.Color.Red;
                        break;

                    case "27":
                        btn_27.Enabled = false;
                        btn_27.BackColor = System.Drawing.Color.Red;
                        break;

                    case "28":
                        btn_28.Enabled = false;
                        btn_28.BackColor = System.Drawing.Color.Red;
                        break;

                    case "29":
                        btn_29.Enabled = false;
                        btn_29.BackColor = System.Drawing.Color.Red;
                        break;

                    case "30":
                        btn_30.Enabled = false;
                        btn_30.BackColor = System.Drawing.Color.Red;
                        break;
                }
            }
        }

        public void setseat()
        {
            btn_1.Enabled = true;
            btn_1.BackColor = System.Drawing.Color.Transparent;
            btn_2.Enabled = true;
            btn_2.BackColor = System.Drawing.Color.Transparent;
            btn_3.Enabled = true;
            btn_3.BackColor = System.Drawing.Color.Transparent;
            btn_4.Enabled = true;
            btn_4.BackColor = System.Drawing.Color.Transparent;
            btn_5.Enabled = true;
            btn_5.BackColor = System.Drawing.Color.Transparent;
            btn_6.Enabled = true;
            btn_6.BackColor = System.Drawing.Color.Transparent;
            btn_7.Enabled = true;
            btn_7.BackColor = System.Drawing.Color.Transparent;
            btn_8.Enabled = true;
            btn_8.BackColor = System.Drawing.Color.Transparent;
            btn_9.Enabled = true;
            btn_9.BackColor = System.Drawing.Color.Transparent;
            btn_10.Enabled = true;
            btn_10.BackColor = System.Drawing.Color.Transparent;
            btn_11.Enabled = true;
            btn_11.BackColor = System.Drawing.Color.Transparent;
            btn_12.Enabled = true;
            btn_12.BackColor = System.Drawing.Color.Transparent;
            btn_13.Enabled = true;
            btn_13.BackColor = System.Drawing.Color.Transparent;
            btn_14.Enabled = true;
            btn_14.BackColor = System.Drawing.Color.Transparent;
            btn_15.Enabled = true;
            btn_15.BackColor = System.Drawing.Color.Transparent;
            btn_16.Enabled = true;
            btn_16.BackColor = System.Drawing.Color.Transparent;
            btn_17.Enabled = true;
            btn_17.BackColor = System.Drawing.Color.Transparent;
            btn_18.Enabled = true;
            btn_18.BackColor = System.Drawing.Color.Transparent;
            btn_19.Enabled = true;
            btn_19.BackColor = System.Drawing.Color.Transparent;
            btn_20.Enabled = true;
            btn_20.BackColor = System.Drawing.Color.Transparent;
            btn_21.Enabled = true;
            btn_21.BackColor = System.Drawing.Color.Transparent;
            btn_22.Enabled = true;
            btn_22.BackColor = System.Drawing.Color.Transparent;
            btn_23.Enabled = true;
            btn_23.BackColor = System.Drawing.Color.Transparent;
            btn_24.Enabled = true;
            btn_24.BackColor = System.Drawing.Color.Transparent;
            btn_25.Enabled = true;
            btn_25.BackColor = System.Drawing.Color.Transparent;
            btn_26.Enabled = true;
            btn_26.BackColor = System.Drawing.Color.Transparent;
            btn_27.Enabled = true;
            btn_27.BackColor = System.Drawing.Color.Transparent;
            btn_28.Enabled = true;
            btn_28.BackColor = System.Drawing.Color.Transparent;
            btn_29.Enabled = true;
            btn_29.BackColor = System.Drawing.Color.Transparent;
            btn_30.Enabled = true;
            btn_30.BackColor = System.Drawing.Color.Transparent;
        }

        
    }
}
