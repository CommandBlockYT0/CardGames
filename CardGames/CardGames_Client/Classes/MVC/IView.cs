using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames_Client.Classes.MVC
{
    interface IView
    {
        void PrintLn(string text);
        void Print(string text);
        void PrintLn();
        void SetAppTitle(string title);
        string ReadLn();
        void SetColor(Colors color);
        void ResetColor();
        void DisplayCard(Card card, IController controller);
        void DisplayCard(Suits suit, int value, IController controller);
    }
}
