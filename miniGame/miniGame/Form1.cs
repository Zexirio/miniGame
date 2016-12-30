using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace miniGame
{
    public partial class Form1 : Form
    {
        bool isHost;
        byte[] bytes_in = new byte[1024];
        byte[] bytes_out = new byte[1024];
        Server myServer;
        Client myClient;

        public Form1() { InitializeComponent(); }

        public void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            richTextBox1.ReadOnly = true;
            DialogResult dialogResult = MessageBox.Show("Host?", "-", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                isHost = true;
                myServer = new Server(this, pg);
                connectingBUTTON.Enabled = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                myClient = new Client( this
                                     , richTextBox1
                                     , serverIP.Text
                                     , pg
                                     , 9999 );
                isHost = false;
            }

        }
        public void mover(object sender, KeyEventArgs e)
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

                myClient.getClient().Send(bytes, bytes.Length, SocketFlags.None);
            }
        }

        public void button2_Click(object sender, EventArgs e) {
            myClient.connect();
            if(myClient.getClient().Connected) { button2.Enabled = true; }
        }

        public void setEnabled(bool status) {
            if (ControlInvokeRequired(button2, () => button2.Enabled = status)) return;
            button2.Enabled = status;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.CheckState == CheckState.Checked) { pg.Focus(); }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (isHost)
            {
                Socket cliente = myServer.getClient();
                Chat("Host: " + MessageToSend.Text);
                byte[] bytes = Encoding.ASCII.GetBytes("Host: " + MessageToSend.Text);
                cliente.Send(bytes, bytes.Length, SocketFlags.None);
                MessageToSend.Clear();
            }
            else
            {
                Socket cliente = myClient.getClient();
                Chat("Client: " + MessageToSend.Text);
                byte[] bytes = Encoding.ASCII.GetBytes("Client: " + MessageToSend.Text);
                cliente.Send(bytes, bytes.Length, SocketFlags.None);
            }
            MessageToSend.Clear();
        }

        public void Chat(string msg)
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

        private void MessageToSend_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }
    }
}
