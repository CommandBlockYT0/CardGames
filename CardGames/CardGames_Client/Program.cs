using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using SetiLab;
using CardGames_Client.Classes.MVC;

namespace CardGames_Client
{
    class Program
    {
        static bool connected = false;
        static IView view = new ConsoleView();
        static IModel model = new Model();
        static IController controller = new Controller();
        static NetworkManager manager;
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            IPAddress ip = null;
            view.SetAppTitle("Карточные игры");
            do
            {
                view.Print("Введите IP сервера: ");
                string _ip = Console.ReadLine();
                try
                {
                    ip = IPAddress.Parse(_ip);
                    connected = model.Connect(ip, out client);
                }
                catch
                {
                    view.PrintLn("Что-то пошло не так.");
                    client = null;
                }
            } while (ip == null && client == new TcpClient());

            if (connected) 
            { 
                view.PrintLn("Подключились!");
                manager = new NetworkManager(client.GetStream());
                string[] serverAnswer = manager.GetMessage().Split(':');
                
                if (serverAnswer[0] == "CARDPLAYERID") view.PrintLn($"Чтобы ваш оппонент смог подключиться, сообщите ему этот код: {serverAnswer[1]}");
            }
            else view.PrintLn("Ошибка подключения");

            Console.OutputEncoding = Encoding.UTF8;

            view.DisplayCard(Suits.Черви, 13, controller);

            view.ReadLn();
        }

    }
}
