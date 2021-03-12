using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames_Client.Classes.MVC
{
    class Controller : IController
    {
        static Dictionary<Suits, object[]> suits;
        static char[] after10;

        public Dictionary<Suits, object[]> Suits => suits;
        public char[] After10 => after10;

        public bool CardMin2 => true;

        public Controller()
        {
            suits = new Dictionary<Suits, object[]>(4);
            after10 = new char[4];
            after10[0] = 'В';
            after10[1] = 'Д';
            after10[2] = 'К';
            after10[3] = 'Т';

            Func<char, Colors, object[]> f = (ch, col) =>
            {
                object[] o = { ch, col };
                return o;
            };

            suits.Add(MVC.Suits.Бубны,  f('♦', Colors.Red));
            suits.Add(MVC.Suits.Пики,   f('♠', Colors.Black));
            suits.Add(MVC.Suits.Черви,  f('♥', Colors.Red));
            suits.Add(MVC.Suits.Крести, f('♣', Colors.Black));
        }
    }
}
