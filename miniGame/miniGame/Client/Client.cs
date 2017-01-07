using System;
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
        public Client(Form1 form1, string serverIP, int port) {
            this.serverIP = serverIP;
            this.form1 = form1;
            this.port = port;
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
                form1.setButtonStatus(new string[] { "sendBUTTON" }, new bool[] { false });
            }
        }

        private void OnSend(IAsyncResult ar) { client.EndSend(ar); }

        private void OnConnect(IAsyncResult ar) {
            if (client.Connected) {
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
               form1.setButtonStatus(new string[] { "sendBUTTON" }
                                     , new bool[] { true });
                form1.changeLabel(true);
            } else {
               // MessageBox.Show("Not Connected");
                form1.setButtonStatus( new string[] { "connectingBUTTON"}, new bool[] { false});
                form1.changeLabel(false);
            }
        }

        private void OnReceive(IAsyncResult ar) {
            client = (Socket)ar.AsyncState;
            try {
                client.EndReceive(ar);
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
                form1.Chat(Encoding.GetEncoding("iso-8859-1").GetString(bytes_in));
                Array.Clear(bytes_in, 0, bytes_in.Length);
            } catch (Exception ex) {
                if (!client.Connected) {
                    client.Close();
                    form1.setButtonStatus(new string[] { "sendBUTTON" }, new bool[] { false });
                    form1.setButtonStatus(new string[] { "connectingBUTTON" }, new bool[] { false });
                    form1.changeLabel(false);
                } else {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
    }
}
