﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace miniGame {
    public interface IServer {
        Socket getClient();
        Socket getServer();
        void Move(int x, int y);
        void createServer();
    }
}
