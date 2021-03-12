using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames_Client.Classes.MVC
{
    class ConsoleView : IView
    {
        public void Print(string text) => Console.Write(text);

        public void PrintLn(string text) => Console.WriteLine(text);

        public void PrintLn() => Console.WriteLine();

        public void SetAppTitle(string text) => Console.Title = text;

        public string ReadLn() => Console.ReadLine();

        public void SetColor(Colors color) => Console.ForegroundColor = (color == Colors.Red) ? ConsoleColor.Red : ConsoleColor.Black;

        public void ResetColor() => Console.ResetColor();

        public void DisplayCard(Suits suit, int value, IController controller)
        {
            controller.Suits.TryGetValue(suit, out object[] cardData);
            PrintLn(" ――― ");
            Print("|");
            SetColor((Colors)cardData[1]);
            Print($"{cardData[0]}{(value <= 10 ? $"{(value == 10 ? $"{value}" : $"{value} ")}" : $"{controller.After10[value - 11]}")} ");
            ResetColor();
            PrintLn("|");
            PrintLn("|   |");
            PrintLn(" ――― ");
        }

        public void DisplayCard(Card card, IController controller) => DisplayCard(card.Suit, card.Value, controller);
    }
}
