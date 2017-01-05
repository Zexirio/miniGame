using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace miniGame
{
    public partial class Form1 : Form, IForm
    {
        bool isHost;
        byte[] bytes_in = new byte[1024];
        byte[] bytes_out = new byte[1024];
        IServer myServer;
        IClient myClient;

        public Form1() { InitializeComponent(); }

        public void Form1_Load(object sender, EventArgs e)
        {
            sendBUTTON.Enabled = false;
            richTextBox1.ReadOnly = true;
        }

        /******** Sono metodi richiamati dalle classi server/client per rilasciare modifiche ai controlli ********/
        public void Chat(string msg)
        {
            if (Utils.ControlInvokeRequired(richTextBox1, () => Chat(msg))) return;
            richTextBox1.AppendText(msg);
            richTextBox1.AppendText("\n");
            //autoscroll to the end
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        public void setButtonStatus(string[] controlNames, bool[] status)
        {
            if (controlNames.Length != status.Length)
            {
                throw new Exception("Impossible to set button status:\n"
                                   + "control to set: " + controlNames.Length
                                   + "\n status to set " + status.Length);
            }
            else
            {
                for (int i = 0; i < controlNames.Length; i++)
                {
                    switch (controlNames[i])
                    {
                        case "sendBUTTON":
                            if (Utils.ControlInvokeRequired(sendBUTTON, () => sendBUTTON.Enabled = status[i])) return;
                            if (!status[i])
                            {
                                if (Utils.ControlInvokeRequired(sendBUTTON, () => sendBUTTON.Text = "MI CONNEGGIO")) return;
                                sendBUTTON.Text = "MI CONNEGGIO";
                            }
                            sendBUTTON.Enabled = status[i];
                            break;
                        case "hostBUTTON":
                            if (Utils.ControlInvokeRequired(hostingBUTTON, () => hostingBUTTON.Enabled = status[i])) return;
                            hostingBUTTON.Enabled = status[i];
                            break;
                        case "connectingBUTTON":
                            if (Utils.ControlInvokeRequired(connectingBUTTON, () => connectingBUTTON.Text = Text)) return;
                            connectingBUTTON.Text = Text;
                            break;
                        default:
                            throw new Exception("Control" + controlNames[i] + "not exist!");
                    }
                }
            }
        }

        public void changeLabel(bool status) {
            if(status)
            {
                Utils.ControlInvokeRequired(label1, () => label1.Text = "Connected");
                Utils.ControlInvokeRequired(label1, () => label1.ForeColor = System.Drawing.Color.Green);
            }
            else
            {
                Utils.ControlInvokeRequired(label1, () => label1.Text = "Not connected");
                Utils.ControlInvokeRequired(label1, () => label1.ForeColor = System.Drawing.Color.Red);
            }
            
        }
        /***********************************************************************************************************/


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
                myClient.getClient().Send(bytes, bytes.Length, SocketFlags.None);
            }
        }

        private void connectingBUTTON_Click(object sender, EventArgs e)
        {
            if (connectingBUTTON.Text.Equals("MI CONNEGGIO"))
            {
                //DialogResult dialogResult = MessageBox.Show("Vuoi avvià la connessione?", "-", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                    connectingBUTTON.Text = "CHIUDO";
                    isHost = false;
                    startClient();
                    hostingBUTTON.Enabled = false;
                //}
            }
            else if (connectingBUTTON.Text.Equals("CHIUDO"))
            {
                connectingBUTTON.Text = "MI CONNEGGIO";
                hostingBUTTON.Enabled = true;
                closeClient();
            }
        }

        private void HostingBUTTON_Click(object sender, EventArgs e)
        {
            if (hostingBUTTON.Text.Equals("ECCHIUDI"))
            {
                hostingBUTTON.Text = "HOSTIO";
                connectingBUTTON.Enabled = true;
                closeServer();
                if (myClient != null) { closeClient(); }
            }
            else if (hostingBUTTON.Text.Equals("HOSTIO"))
            {
                //DialogResult dialogResult = MessageBox.Show("Vuoi avvià il server?", "-", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                    hostingBUTTON.Text = "ECCHIUDI";
                    isHost = true;
                    if (myClient != null) { closeClient(); }
                    startServer();
                    connectingBUTTON.Enabled = false;
                //
            }
            else
            { /*boh non dovrebbe entrare qua dentro*/
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked) { pg.Focus(); }
        }

        private void sendBUTTON_Click(object sender, EventArgs e)
        {
            string whoIsThis;
            if (isHost)
            {
               
                whoIsThis = "Host: ";
                byte[] bytes = Encoding.ASCII.GetBytes(whoIsThis + MessageToSend.Text);
                myServer.getClient().Send(bytes, bytes.Length, SocketFlags.None);
            }
            else
            {
                whoIsThis = "Client: ";
                byte[] bytes = Encoding.ASCII.GetBytes(whoIsThis + MessageToSend.Text);
                myClient.getClient().Send(bytes, bytes.Length, SocketFlags.None);
            }
            Chat(whoIsThis + MessageToSend.Text);
            MessageToSend.Clear();
        }

        private void MessageToSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { sendBUTTON.PerformClick(); }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) { }

        public void startServer()
        {
            if (myServer != null && myServer.getClient() != null) { closeServer(); }
            isHost = true;
            myServer = new Server(this, pg);
            connectingBUTTON.Enabled = false;
        }

        private void startClient()
        {
            if (myClient != null && myClient.getClient() != null) { closeClient(); }
            connectingBUTTON.Enabled = true;
            myClient = new Client(this, serverIP.Text, 9999, label1);
            isHost = false;
            myClient.connect();
        }

        private void closeServer()
        {
            if (myServer.getServer() != null)
            {
                if (myServer.getClient() != null) { myServer.getClient().Close(); }
                myServer.getServer().Close();
            }
        }

        private void closeClient()
        {
            if (myClient.getClient() != null) { myClient.getClient().Close(); }
        }

    }
}
