using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace miniGame
{
    class Client
    {
        RichTextBox rtb;
        Button pg;
        Form1 f1;
        Socket client;
        byte[] bytes_in = new byte[1024];
        string serverIP;
        int port;
        public Client( Form1 f1
                     , RichTextBox rtb
                     , string serverIP
                     , Button pg
                     , int port ) {
            this.rtb = rtb;
            this.serverIP = serverIP;
            this.pg = pg;
            this.f1 = f1;
            this.port = port;
        }

        public Socket getClient() { return client; }

        public void connect() {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.BeginConnect(
                  new IPEndPoint(IPAddress.Parse(serverIP), port)
                , new AsyncCallback(OnConnect)
                , null);
        }

        private void OnSend(IAsyncResult ar) { client.EndSend(ar); }

        private void OnConnect(IAsyncResult ar) {
            if (client.Connected) {
                MessageBox.Show("Connected");
            } else {
                MessageBox.Show("Not Connected");
            }
            client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
        }

        private void OnReceive(IAsyncResult ar) {
            client = (Socket)ar.AsyncState;
            client.EndReceive(ar);
            client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
            string message = System.Text.ASCIIEncoding.ASCII.GetString(bytes_in);
            f1.Chat(message);
        }
    }
}
