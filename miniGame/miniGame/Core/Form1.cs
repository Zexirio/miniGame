using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace miniGame {
    public partial class Form1 : Form, IForm {
        bool isHost;
        byte[] bytes_in = new byte[1024];
        byte[] bytes_out = new byte[1024];
        Encoding enc = Encoding.GetEncoding(Constants.ENCODINGFORMAT);
        IServer myServer;
        IClient myClient;
        Button myPlayer = new Button();

        public Form1() { InitializeComponent(); }

        public void Form1_Load(object sender, EventArgs e) { }

        /******** Sono metodi richiamati dalle classi server/client per rilasciare modifiche ai controlli ********/
        public void Chat(string msg) {
            if (Utils.ControlInvokeRequired(richTextBox1, () => Chat(msg))) return;
            richTextBox1.AppendText(msg);
            richTextBox1.AppendText("\n");
            //autoscroll to the end
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        public void updateControl(string[] controlNames, bool[] status) {
            if (controlNames.Length != status.Length) {
                throw new Exception("Impossible to set button status:\n"
                                   + "control to set: " + controlNames.Length
                                   + "\n status to set " + status.Length);
            } else {
                for (int i = 0; i < controlNames.Length; i++) {
                    switch (controlNames[i]) {
                        case Constants.SENDBUTTON_NAME:
                            Utils.ControlInvokeRequired(sendBUTTON, () => sendBUTTON.Enabled = status[i]);
                            break;
                        case Constants.CONNECTINGBUTTON_NAME:
                            if(!status[i]) {
                                if(myClient != null) { closeClient(); }
                                Utils.ControlInvokeRequired(connectingBUTTON, () => connectingBUTTON.Text = Constants.CONNECTINGBUTTON_CONNECT);
                            }
                            break;
                        case Constants.CONNECTIONSTATUSLABEL_NAME:
                            if (status[i]) {
                                Utils.ControlInvokeRequired(connectionStatusLABEL, () => connectionStatusLABEL.Text = Constants.CONNECTIONSTATUSLABEL_CONNECTED);
                                Utils.ControlInvokeRequired(connectionStatusLABEL, () => connectionStatusLABEL.ForeColor = System.Drawing.Color.Green);
                            } else {
                                Utils.ControlInvokeRequired(connectionStatusLABEL, () => connectionStatusLABEL.Text = Constants.CONNECTIONSTATUSLABEL_NOTCONNECTED);
                                Utils.ControlInvokeRequired(connectionStatusLABEL, () => connectionStatusLABEL.ForeColor = System.Drawing.Color.Red);
                            }
                            break;
                        case Constants.MOVEMENTCHECKBOX_NAME:
                            Utils.ControlInvokeRequired(moveCheckbox, () => moveCheckbox.Enabled = status[i]);
                            break;
                        default:
                            throw new Exception("Control" + controlNames[i] + "not exist!");
                    }
                }
            }
        }
        /***********************************************************************************************************/

        private void mover(object sender, KeyEventArgs e) {
            byte[] coord;
            switch (e.KeyCode) {
                case Keys.W:
                    if (myPlayer.Top > 0) { myPlayer.Top -= 5; }
                    break;

                case Keys.S:
                    if (myPlayer.Top < (map.Height - myPlayer.Height) - 5) { myPlayer.Top += 5; }
                    break;

                case Keys.A:
                    if (myPlayer.Left > 0) { myPlayer.Left -= 5; }
                    break;

                case Keys.D:
                    if (myPlayer.Left < (map.Width - myPlayer.Width) - 5) { myPlayer.Left += 5; }
                    break;
            }
            coord = enc.GetBytes("mov," + myPlayer.Location.X + "," + myPlayer.Location.Y);
            if(isHost) {
                Thread.Sleep(750);
                if (myPlayer.Focused) { myServer.getClient().Send(coord, coord.Length, SocketFlags.None); }
            } else {
                Thread.Sleep(750);
                if (myPlayer.Focused) { myClient.getClient().Send(coord, coord.Length, SocketFlags.None); }
            }
            coordinates.Text = myPlayer.Location.X + ":" + myPlayer.Location.Y;
        }

        private void connectingBUTTON_Click(object sender, EventArgs e) {
            if (connectingBUTTON.Text.Equals(Constants.CONNECTINGBUTTON_CONNECT)) {
                connectingBUTTON.Text = Constants.CONNECTINGBUTTON_DISCONNECT;
                isHost = false;
                connectionStatusLABEL.Text = Constants.CONNECTIONSTATUSLABEL_SEARCHING;
                connectionStatusLABEL.ForeColor = System.Drawing.Color.Blue;
                startClient();
            } else if (connectingBUTTON.Text.Equals(Constants.CONNECTINGBUTTON_DISCONNECT)) {
                connectingBUTTON.Text = Constants.CONNECTINGBUTTON_CONNECT;
                closeClient();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (moveCheckbox.CheckState == CheckState.Checked) {
                if (isHost)
                {
                    playerH.Enabled = true;
                    playerH.ForeColor = System.Drawing.Color.Green;
                    playerH.Focus();
                }
                else
                {
                    playerC.Enabled = true;
                    playerC.ForeColor = System.Drawing.Color.Green;
                    playerC.Focus();
                }
            }
        }

        private void sendBUTTON_Click(object sender, EventArgs e) {
            string msgToSend;
            if (isHost) {
                msgToSend = "Host: " + MessageToSend.Text;
                byte[] bytes = enc.GetBytes(msgToSend);
                myServer.getClient().Send(bytes, bytes.Length, SocketFlags.None);
            } else {
                msgToSend = "Client: " + MessageToSend.Text;
                byte[] bytes = enc.GetBytes(msgToSend);
                myClient.getClient().Send(bytes, bytes.Length, SocketFlags.None);
            }
            Chat(msgToSend);
            MessageToSend.Clear();
        }

        private void MessageToSend_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) { sendBUTTON.PerformClick(); }
        }

        private void startServer() {
            if (myServer != null && myServer.getClient() != null) { closeServer(); }
            isHost = true;
            myServer = new Server(this, playerC);
            connectingBUTTON.Enabled = false;
            myPlayer = playerH;
        }

        private void startClient() {
            if (myClient != null && myClient.getClient() != null) { closeClient(); }
            connectingBUTTON.Enabled = true;
            myClient = new Client(this, serverIP.Text, 9999, playerH);
            isHost = false;
            myClient.connect();
            myPlayer = playerC;
        }

        private void closeServer() {
            if (myServer.getServer() != null) {
                if (myServer.getClient() != null) { myServer.getClient().Close(); }
                myServer.getServer().Close();
            }
        }

        private void closeClient() {
            if (myClient.getClient() != null) { myClient.getClient().Close(); }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) {
                isHost = true;
                if (myClient != null) { closeClient(); }
                startServer();
                connectingBUTTON.Enabled = false;
            }
            else {
                connectingBUTTON.Enabled = true;
                closeServer();
                if (myClient != null) { closeClient(); }
                myServer.createServer();
            }
        }

        private void map_Click(object sender, EventArgs e)
        {
            if (moveCheckbox.Checked) { myPlayer.Focus(); }
        }

        private void playerH_Click(object sender, EventArgs e)
        {
            myPlayer.Focus();
        }

        private void playerC_Click(object sender, EventArgs e)
        {
            myPlayer.Focus();
        }
    }
}
