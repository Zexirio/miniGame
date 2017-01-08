using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace miniGame {
    public class Server : IServer {
        IForm form1;
        Button player1;
        Socket server = default(Socket);
        Socket client = default(Socket);
        byte[] bytes_in = new byte[1024];

        public Server(Form1 form1, Button player1) {
            this.form1 = form1;
            this.player1 = player1;
            //createServer();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            server.Bind(new IPEndPoint(IPAddress.Any, 9999));
            server.Listen(2);
            server.BeginAccept(new AsyncCallback(OnAccept_Server), null);

        }

        public void createServer() {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        private void OnAccept_Server(IAsyncResult ar) {
            try {
                client = server.EndAccept(ar);
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
                form1.updateControl( new string[] { Constants.SENDBUTTON_NAME, Constants.CONNECTIONSTATUSLABEL_NAME, Constants.MOVEMENTCHECKBOX_NAME }
                                   , new bool[] { true, true, true });
            } catch (Exception ex) {
                //fottesega
            }
        }

        private void OnReceive_Server(IAsyncResult ar) {
            client = (Socket)ar.AsyncState;
            try {
                client.EndReceive(ar);
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
                string message = Encoding.GetEncoding(Constants.ENCODINGFORMAT).GetString(bytes_in);
                if (message.StartsWith("mov")) {
                    string[] xy = message.Split(',');
                    Move(Convert.ToInt32(xy[1]), Convert.ToInt32(xy[2]));
                }
                else { form1.Chat(message); }
                
                Array.Clear(bytes_in, 0, bytes_in.Length);
            } catch (Exception ex) {
                if (!client.Connected) {
                    client.Close();
                    form1.updateControl( new string[] { Constants.SENDBUTTON_NAME, Constants.CONNECTIONSTATUSLABEL_NAME, Constants.MOVEMENTCHECKBOX_NAME }
                                       , new bool[] { false, false, false });
                    server.Close();
                } else {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        public void Move(int x, int y) {
            if (Utils.ControlInvokeRequired(player1, () => Move(x, y))) return;
            player1.Location = new Point(x, y);
        }

        public Socket getClient() { return client; }
        public Socket getServer() { return server; }
    }
}
