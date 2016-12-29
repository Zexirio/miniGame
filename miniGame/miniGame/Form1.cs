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
        bool isHost;
        Socket client;
        string host = "25.108.14.68";
        int port = 9999;
        byte[] bytes_in = new byte[1024];
        Socket server = default(Socket);
        Socket client_ = default(Socket);
        byte[] bytes_out = new byte[1024];


        public Form1()
        {
            InitializeComponent();
        }


        //Client -----------------------------------
        //---------------------------------------------------------------
        private void OnSend(IAsyncResult ar)
        {
            client.EndSend(ar);
        }

        private void OnConnect(IAsyncResult ar)
        {
            //client.EndConnect(ar)
            if (client.Connected == true)
            {
                MessageBox.Show("Connected");
            }
            else
            {
                MessageBox.Show("Not Connected");
            }
            client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
        }

        private void OnReceive(IAsyncResult ar)
        {
            client = (Socket)ar.AsyncState;
            client.EndReceive(ar);
            client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
            string message = System.Text.ASCIIEncoding.ASCII.GetString(bytes_in);
            Chat(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress IP = IPAddress.Parse(host);
            IPEndPoint xIpEndPoint = new IPEndPoint(IP, port);
            client.BeginConnect(xIpEndPoint, new AsyncCallback(OnConnect), null);
        }

        private void mover(object sender, KeyEventArgs e)
        {
            byte[] bytes;
            bool moved = false;
            switch (e.KeyCode)
            {
                case Keys.W:
                    pg.Top -= 5;
                    moved = true;
                    break;

                case Keys.S:
                    pg.Top += 5;
                    moved = true;
                    break;

                case Keys.A:
                    pg.Left -= 5;
                    moved = true;
                    break;

                case Keys.D:
                    pg.Left += 5;
                    moved = true;
                    break;
            }
            if (moved)
            {
                bytes = Encoding.ASCII.GetBytes("mov," + pg.Location.X + "," + pg.Location.Y);

                client.Send(bytes, bytes.Length, SocketFlags.None);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isHost == false)
            {
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    pg.Focus();
                }
            }
        }
        //------------------------------------------------------------------
        //------------------------------------------------------------------
        //------------------------------------------------------------------
        //------------------------------------------------------------------




        //Roba Server ----------------------------
        //---------------------------------------------------------------
        public void Form1_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Host?", "-", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                isHost = true;
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint xEndpoint = new IPEndPoint(IPAddress.Any, 9999);
                server.Bind(xEndpoint);
                server.Listen(2);
                server.BeginAccept(new AsyncCallback(OnAccept_Server), null);
                connectingBUTTON.Enabled = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                isHost = false;
            }
           
        }
        private void OnAccept_Server(IAsyncResult ar)
        {
            if (isHost)
            { 
            client_ = server.EndAccept(ar);
            client_.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client_);
            }
        }
        private void OnReceive_Server(IAsyncResult ar)
        {
            if (isHost)
            {
                client_ = (Socket)ar.AsyncState;
                client_.EndReceive(ar);
                client_.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client_);
                string message = System.Text.ASCIIEncoding.ASCII.GetString(bytes_in);
                //if (Convert.ToString(bytes) == "/ip") {MessageBox.Show("Richiesta ip(???)");}
                if (message.Contains("mov"))
                {
                    string[] xy = message.Split(',');
                    // button2.Location = new Point(Convert.ToInt32(xy[1]), Convert.ToInt32(xy[2]));
                    Move(Convert.ToInt32(xy[1]), Convert.ToInt32(xy[2]));
                }
                Chat(message);
            }
            
           
        }
        public void Move(int x, int y)
        {
            if (isHost)
            {
                if (ControlInvokeRequired(pg, () => Move(x, y))) return;
                pg.Location = new Point(x, y);
            }
            
        }
        //---------------------------------------------------------------------
        //--------------------------------------------------------



        

       

        private void button3_Click(object sender, EventArgs e)
        {

        }


        //Both
        //---------------------
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (isHost)
            {
                Chat("Host: " + MessageToSend.Text);
                byte[] bytes = Encoding.ASCII.GetBytes("Host: " + MessageToSend.Text);
                client_.Send(bytes, bytes.Length, SocketFlags.None);
                MessageToSend.Clear();
            }
            else
            {
                Chat("Client: " + MessageToSend.Text);
                byte[] bytes = Encoding.ASCII.GetBytes("Client: " + MessageToSend.Text);
                client.Send(bytes, bytes.Length, SocketFlags.None);
            }
            MessageToSend.Clear();
        }
        public void Chat(String msg)
        {
            if (ControlInvokeRequired(richTextBox1, () => Chat(msg))) return;
            richTextBox1.AppendText(msg);
            richTextBox1.AppendText("\n");
        }
        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;

            return true;
        }
        
    }
}
