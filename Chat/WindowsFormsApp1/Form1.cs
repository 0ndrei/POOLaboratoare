using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Socket sck;                                                        //Avem clasa soket care are ca variabila sck
        EndPoint epLocal, epRemote;                                        //Avem clasa EndPoin care are ca variabila eplocal,epremote
        byte[] buffer;                                                     // Avem clasa byte care are ca variabila buffer

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                          //Configuratia chat-ului
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //Initializarea utiliztorilor
            textBox1.Text = GetLocalIP();
            textBox3.Text = GetLocalIP();
        }

        private string GetLocalIP()      //Conectarea utilizatorilor la IP adresa 
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "177.0.0.0";
        }
        private void button1_Click(object sender, EventArgs e)  // butonul de conectare 
        {
            //Conectam butonul cu ambii ultilzatori 
            epLocal = new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(textBox2.Text));
            sck.Bind(epLocal);
            // Conectam al doilea utilizator la chat 
            epRemote = new IPEndPoint(IPAddress.Parse(textBox3.Text), Convert.ToInt32(textBox4.Text));
            sck.Connect(epRemote);
            //Alegem portul dorit
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBlack), buffer);
        }

        private void button2_Click(object sender, EventArgs e)           // butonul sent 
        {  
            //Convertarea mesajului in octet
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            sendingMessage = aEncoding.GetBytes(textBox5.Text);
            //Trimiterea mesajului codificat
            sck.Send(sendingMessage);
            //Adaugarea in listbox
            listBox1.Items.Add("Me: " + textBox5.Text);
            textBox5.Text = "";
        }

        private void MessageCallBlack(IAsyncResult aResult)
        {  //try si catch este folosit pentru a elimina erorile cind se foloseste transmiterea unui fail cu ajutorul la retea
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[])aResult.AsyncState;
                // Convertatrea ovtetului in string 
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receivedMessage = aEncoding.GetString(receivedData);
                //Adaugarea mesajului in listBox
                listBox1.Items.Add("Friend: " + receivedMessage);
                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBlack), buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}