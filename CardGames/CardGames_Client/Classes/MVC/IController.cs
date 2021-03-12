using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames_Client.Classes.MVC
{//              Бубны♦ Крести♣ Черви♥ Пики♠
    enum Suits  : byte { Бубны, Крести, Черви, Пики}
    enum Colors : byte { Black, Red }
    enum CardValueNonNum { Валет, Дама, Король, Туз }

    interface ICardData { }
    interface IController
    {
        bool CardMin2 { get; }
        Dictionary<Suits, object[]> Suits { get; }
        char[] After10 { get; }
    }
}
