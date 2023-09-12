using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuldkortetServer.Models
{
    public class Card
    {
        private string cardType;

        private string cardId;
        public string CardId { get { return cardId; } set { cardId = value; } }
        public string CardType { get { return cardType; } set { cardType = value; } }


        public Card(string _cardId) 
        { 
         cardId = _cardId; // Set the card id
            cardType = "Null";
        }
        // Virtual string, other card types will have an overwrite string. 
        public virtual string ToString() 
        {
            return ($"Du vann tyvärr inte )=, försök igen!");
        }
    }


    public class Dunderkatt : Card 
    {
        public Dunderkatt(string _cardId) : base(_cardId)  // We create the dunderkatt and send the cardId parameters to the base class
        {
            CardType = "Dunderkatt";
        }

        public override string ToString()
        {
            return ($"{CardType} Vinst!!! Grattis!!! Du vann något helt unikt!");
        }
    }

    public class Kristallhäst : Card
    {
        public Kristallhäst(string _cardId) : base(_cardId)  // We create the dunderkatt and send the cardId parameters to the base class
        {
            CardType = "Kristallhäst";
        }

        public override string ToString()
        {
            return ($"{CardType} Vinst!!! Grattis!!! Du vann något extra!");
        }
    }

    public class Överpanda : Card
    {
        public Överpanda(string _cardId) : base(_cardId)  // We create the dunderkatt and send the cardId parameters to the base class
        {
            CardType = "Överpanda";
        }

        public override string ToString()
        {
            return ($"{CardType} Vinst!!! Grattis!!! Du vann något fantastiskt!");
        }
    }

    public class Eldtomat : Card
    {
        public Eldtomat(string _cardId) : base(_cardId)  // We create the dunderkatt and send the cardId parameters to the base class
        {
            CardType = "Eldtomat";
        }

        public override string ToString()
        {
            return ($"{CardType} Vinst!!! Grattis!!! Du vann något specielt!");
        }
    }
}
