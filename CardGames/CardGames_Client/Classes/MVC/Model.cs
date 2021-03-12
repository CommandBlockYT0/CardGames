using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using SetiLab;

namespace CardGames_Client.Classes.MVC
{
    class Model : IModel
    {
        public bool Connect(IPAddress ip, out TcpClient client)
        {
            client = new TcpClient();
            bool connected = false;
            client.BeginConnect(ip, 13137, ar => connected = true, null);

            for (int i = 0; i < 10; i++)
            {
                if (connected) break;
                Thread.Sleep(100);
            }
            return connected;
        }
    }
}
