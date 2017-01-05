using System.Net.Sockets;

namespace miniGame
{
    interface IClient
    {
        Socket getClient();
        void connect();
    }
}
