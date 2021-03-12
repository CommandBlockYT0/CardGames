using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using SetiLab;

namespace CardGames_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CardGames Server";
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 13137);
            server.Start();
            Dictionary<string, TcpClient> players = new Dictionary<string, TcpClient>();
            Random random = new Random();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                int id = random.Next(1000000000, int.MaxValue);
                players.Add(id.ToString(), client);
                NetworkStream stream = client.GetStream();
                NetworkManager networkManager = new NetworkManager(stream);
                networkManager.SendMessage($"CARDPLAYERID:{id}");
                Console.WriteLine($"Player connected with id {id}");
            }
        }
    }
}
