using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace miniGame {
    public partial class Form1 : Form, IForm {
        bool isHost;
        byte[] bytes_in = new byte[1024];
        byte[] bytes_out = new byte[1024];
        Encoding enc = Encoding.GetEncoding(Constants.ENCODINGFORMAT);
        IServer myServer;
        IClient myClient;

        public Form1() { InitializeComponent(); }

        public void Form1_Load(object sender, EventArgs e) {
            sendBUTTON.Enabled = false;
            richTextBox1.ReadOnly = true;
        }

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
                        default:
                            throw new Exception("Control" + controlNames[i] + "not exist!");
                    }
                }
            }
        }
        /***********************************************************************************************************/


        private void mover(object sender, KeyEventArgs e) {
            byte[] bytes;
            bool moved = false;
            switch (e.KeyCode) {
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
            if (moved) {
                bytes = Encoding.ASCII.GetBytes("mov," + pg.Location.X + "," + pg.Location.Y);
                myClient.getClient().Send(bytes, bytes.Length, SocketFlags.None);
            }
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
            if (checkBox1.CheckState == CheckState.Checked) { pg.Focus(); }
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

        private void radioButton_CheckedChanged(object sender, EventArgs e) { }

        private void startServer() {
            if (myServer != null && myServer.getClient() != null) { closeServer(); }
            isHost = true;
            myServer = new Server(this, pg);
            connectingBUTTON.Enabled = false;
        }

        private void startClient() {
            if (myClient != null && myClient.getClient() != null) { closeClient(); }
            connectingBUTTON.Enabled = true;
            myClient = new Client(this, serverIP.Text, 9999);
            isHost = false;
            myClient.connect();
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
    }
}
