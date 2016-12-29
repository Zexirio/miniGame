using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace miniGame
{
    public class Server {
        Form1 f1;
        Button pg;
        byte[] bytes_in = new byte[1024];
        Socket server = default(Socket);
        Socket client = default(Socket);

        public Server(Form1 f1, Button pg) {
            this.f1 = f1;
            this.pg = pg;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint xEndpoint = new IPEndPoint(IPAddress.Any, 9999);
            server.Bind(xEndpoint);
            server.Listen(2);
            server.BeginAccept(new AsyncCallback(OnAccept_Server), null);
        }

        public void OnAccept_Server(IAsyncResult ar)
        {
            client = server.EndAccept(ar);
            client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
        }
        private void OnReceive_Server(IAsyncResult ar)
        {
            client = (Socket)ar.AsyncState;
            client.EndReceive(ar);
            client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
            string message = Encoding.ASCII.GetString(bytes_in);
            if (message.Contains("mov"))
            {
                string[] xy = message.Split(',');
                Move(Convert.ToInt32(xy[1]), Convert.ToInt32(xy[2]));
            }
            f1.Chat(message);
        }
        public void Move(int x, int y)
        {
            if (f1.ControlInvokeRequired(pg, () => Move(x, y))) return;
            pg.Location = new Point(x, y);

        }
        public Socket getClient() { return client; }
    }
}
