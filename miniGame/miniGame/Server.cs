using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace miniGame
{
    public class Server {
        Form1 f1;
        Button pg;
        Socket server = default(Socket);
        Socket client = default(Socket);
        byte[] bytes_in = new byte[1024];

        public Server(Form1 f1, Button pg) {
            this.f1 = f1;
            this.pg = pg;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint xEndpoint = new IPEndPoint(IPAddress.Any, 9999);
            server.Bind(xEndpoint);
            server.Listen(2);
            server.BeginAccept(new AsyncCallback(OnAccept_Server), null);
        }

        private void OnAccept_Server(IAsyncResult ar) {
            client = server.EndAccept(ar);
            client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
            f1.setEnabled(true);
        }

        private void OnReceive_Server(IAsyncResult ar) {
            client = (Socket)ar.AsyncState;
            try {
                client.EndReceive(ar); 
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
                string message = Encoding.ASCII.GetString(bytes_in);
                if (message.Contains("mov")) {
                    string[] xy = message.Split(',');
                    Move(Convert.ToInt32(xy[1]), Convert.ToInt32(xy[2]));
                }
                f1.Chat(message);
            }
            catch (Exception ex) {
                if(!client.Connected) {
                    MessageBox.Show("Client disconnected from session");
                    client.Disconnect(false);
                    f1.setEnabled(false);
                } else {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        public void Move(int x, int y) {
            if (f1.ControlInvokeRequired(pg, () => Move(x, y))) return;
            pg.Location = new Point(x, y);

        }

        public Socket getClient() { return client; }
    }
}
