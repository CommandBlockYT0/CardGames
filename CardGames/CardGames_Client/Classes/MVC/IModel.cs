using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using SetiLab;

namespace CardGames_Client.Classes.MVC
{
    interface IModel
    {
        bool Connect(IPAddress ip, out TcpClient client);
    }
}
