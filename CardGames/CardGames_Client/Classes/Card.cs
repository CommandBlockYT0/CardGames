using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames_Client.Classes.MVC;

namespace CardGames_Client.Classes
{
    class Card
    {
        public Suits Suit { get => suit; }
        public int Value { get => value; }

        private Suits suit;
        private int value;

        public Card(int value, Suits suit)
        {
            this.value = value;
            this.suit = suit;
        }
    }
}
