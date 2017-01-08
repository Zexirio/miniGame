using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace miniGame {
    public class Client : IClient {
        IForm form1;
        Socket client;
        byte[] bytes_in = new byte[1024];
        string serverIP;
        int port;
        Button OnlinePlayer;
        public Client(Form1 form1, string serverIP, int port, Button OnlinePlayer) {
            this.serverIP = serverIP;
            this.form1 = form1;
            this.port = port;
            this.OnlinePlayer = OnlinePlayer;
        }

        public Socket getClient() { return client; }

        public void connect() {
            try {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(
                      new IPEndPoint(IPAddress.Parse(serverIP), port)
                    , new AsyncCallback(OnConnect)
                    , null);
            } catch (Exception ex) {
                MessageBox.Show("Can't connect" + ex.StackTrace);
                form1.updateControl(new string[] { Constants.SENDBUTTON_NAME, Constants.MOVEMENTCHECKBOX_NAME }, new bool[] { false, false });
            }
        }

        private void OnSend(IAsyncResult ar) { client.EndSend(ar); }

        private void OnConnect(IAsyncResult ar) {
            if (client.Connected) {
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
                form1.updateControl(new string[] { Constants.SENDBUTTON_NAME, Constants.CONNECTIONSTATUSLABEL_NAME, Constants.MOVEMENTCHECKBOX_NAME }
                                  , new bool[] { true, true, true });
               
            } else {
                form1.updateControl( new string[] { Constants.CONNECTINGBUTTON_NAME, Constants.CONNECTIONSTATUSLABEL_NAME, Constants.MOVEMENTCHECKBOX_NAME }
                                   , new bool[] { false, false, false });
            }
        }

        private void OnReceive(IAsyncResult ar) {
            client = (Socket)ar.AsyncState;
            try {
                client.EndReceive(ar);
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
                string message = Encoding.GetEncoding(Constants.ENCODINGFORMAT).GetString(bytes_in);
                if (message.StartsWith("mov"))
                {
                    string[] xy = message.Split(',');
                    Move(Convert.ToInt32(xy[1]), Convert.ToInt32(xy[2]));
                }
                else { form1.Chat(message); }
                
                Array.Clear(bytes_in, 0, bytes_in.Length);
            } catch (Exception ex) {
                if (!client.Connected) {
                    client.Close();
                    form1.updateControl( new string[] { Constants.SENDBUTTON_NAME, Constants.CONNECTINGBUTTON_NAME, Constants.CONNECTIONSTATUSLABEL_NAME, Constants.MOVEMENTCHECKBOX_NAME }
                                       , new bool[] { false, false, false, false });
                } else {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        public void Move(int x, int y)
        {
            if (Utils.ControlInvokeRequired(OnlinePlayer, () => Move(x, y))) return;
            OnlinePlayer.Location = new Point(x, y);
        }
    }
}
