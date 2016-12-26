using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniGame
{
    public partial class Form1 : Form
    {
        TcpClient client;
        TcpListener listener;
        bool first = true;
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient clientSocket = new TcpClient();

        public void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        public void msg(string mesg)
        {
            //textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        private void mover(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Console.WriteLine("w");
                    button1.Top -= 5;
                    break;

                case Keys.S:
                    Console.WriteLine("s");
                    button1.Top += 5;
                    break;

                case Keys.A:
                    Console.WriteLine("a");
                    button1.Left -= 5;
                    break;

                case Keys.D:
                    Console.WriteLine("d");
                    button1.Left += 5;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textToSend = DateTime.Now.ToString();

            //---create a TCPClient object at the IP and port no.---
            //TcpClient client = new TcpClient(serverIP.Text, Convert.ToInt32(serverPORT.Text));
            if(first) client = new TcpClient(serverIP.Text, Convert.ToInt32(serverPORT.Text));
            first = false;
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(MessageToSend.Text);

            //---send the text---
            //Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            //Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            //Console.ReadLine();
            /*if(client.Connected) {
                MessageBox.Show("CRISTIDDIO E MIT LA PRIMAAAA");
                connectionTimer.Start();
            }*/
            //client.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(hostingIP.Text);
            //TcpListener listener = new TcpListener(localAdd, Convert.ToInt32(hostingPORT.Text));
            listener = new TcpListener(localAdd, Convert.ToInt32(hostingPORT.Text));

            //Console.WriteLine("Listening...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();
            //if (client.Connected) MessageBox.Show("Va");
;            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //---convert the data received into a string---
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            //Console.WriteLine("Received : " + dataReceived);
            richTextBox1.Text += dataReceived;
            //---write back the text to the client---
            //Console.WriteLine("Sending back : " + dataReceived);
            nwStream.Write(buffer, 0, bytesRead);
            //client.Close();
            //listener.Stop();
            //Console.ReadLine();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(MessageToSend.Text);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }
    }
}
