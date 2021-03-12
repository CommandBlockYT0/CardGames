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
            List<TcpClient> players = new List<TcpClient>();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                players.Add(client);
                NetworkStream stream = client.GetStream();
                NetworkManager networkManager = new NetworkManager(stream);
                networkManager.SendMessage($"PLAYERID:{players.IndexOf(client)}");
                Console.WriteLine($"Player connected with id {players.IndexOf(client)}");
            }
        }
    }
}
