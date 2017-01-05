using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace miniGame
{
    public class Server : IServer
    {
        IForm form1;
        Button pg;
        Socket server = default(Socket);
        Socket client = default(Socket);
        byte[] bytes_in = new byte[1024];

        public Server(Form1 form1, Button pg)
        {
            this.form1 = form1;
            this.pg = pg;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            server.Bind(new IPEndPoint(IPAddress.Any, 9999));
            server.Listen(2);
            server.BeginAccept(new AsyncCallback(OnAccept_Server), null);
        }

        private void OnAccept_Server(IAsyncResult ar)
        {
            try
            {
                client = server.EndAccept(ar);
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
                form1.setButtonStatus(new string[] { "sendBUTTON" }
                                     , new bool[] { true });
                form1.changeLabel(true);
            }
            catch (Exception ex)
            {
                //fottesega
            }
        }

        private void OnReceive_Server(IAsyncResult ar)
        {
            client = (Socket)ar.AsyncState;
            try
            {
                client.EndReceive(ar);
                client.BeginReceive(bytes_in, 0, bytes_in.Length, SocketFlags.None, new AsyncCallback(OnReceive_Server), client);
                string message = Encoding.ASCII.GetString(bytes_in);
                if (message.Contains("mov"))
                {
                    string[] xy = message.Split(',');
                    Move(Convert.ToInt32(xy[1]), Convert.ToInt32(xy[2]));
                }
                form1.Chat(message);
                Array.Clear(bytes_in, 0, bytes_in.Length);
            }
            catch (Exception ex)
            {
                if (!client.Connected)
                {
                    client.Close();

                    //***********//
                    server.Close();
                    //**********//

                    form1.setButtonStatus(new string[] { "sendBUTTON" }
                                         , new bool[] { false });
                    MessageBox.Show("Client disconnected from session");

                    //*****************//
                    form1.startServer();
                    //****************//

                    form1.changeLabel(false);
                }
                else
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        public void Move(int x, int y)
        {
            if (Utils.ControlInvokeRequired(pg, () => Move(x, y))) return;
            pg.Location = new Point(x, y);
        }

        public Socket getClient() { return client; }
        public Socket getServer() { return server; }
    }
}
