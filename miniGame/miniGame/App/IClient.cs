using System.Net.Sockets;

namespace miniGame {
    interface IClient {
        Socket getClient();
        void connect();
        void Move(int x, int y);
    }
}
