using System;
using System.Collections.Generic; 

namespace deck
{
    public class Card{
        public string stringVal  { get; set; }
        public string Suit { get; set; }
        public int Val { get; set; }
        public Card(string suit, string card, int val)
        {
            stringVal = card;
            Suit = suit;
            Val = val;
        }
    }

    public class Deck{
        public List<Card> cards { get; set; }
        public Deck()
        {
            //Initialize empty card list of 52
            cards = new List<Card>();

            //Initialize possible card values
            string[] suits = new string[4] {"Clubs", "Diamonds", "Hearts", "Spades"};
            string[] stringVal = new string[13] {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            int[] val = new int[13] {1, 2, 3, 4 ,5, 6, 7, 8 ,9 ,10, 11, 12, 13};

            //Loop through each suit and add 13 cards per suit
            foreach( string suit in suits)
            {
                for(int i = 0; i < 13; i ++)
                {
                    Card card = new Card(suit, stringVal[i], val[i]);
                    cards.Add(card); 
                }
            }
        }

        public Card deal()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void reset()
        {
            //Initialize empty card list of 52
            cards = new List<Card>();

            //Initialize possible card values
            string[] suits = new string[4] {"Clubs", "Diamonds", "Hearts", "Spades"};
            string[] stringVal = new string[13] {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            int[] val = new int[13] {1, 2, 3, 4 ,5, 6, 7, 8 ,9 ,10, 11, 12, 13};

            //Loop through each suit and add 13 cards per suit
            foreach( string suit in suits)
            {
                for(int i = 0; i < 13; i ++)
                {
                    Card card = new Card(suit, stringVal[i], val[i]);
                    cards.Add(card); 
                }
            }
        }

        public void shuffle()
        {
            Random r = new Random();
            for( int n = cards.Count - 1; n > 0; n--)
            {
                int k = r.Next(n+1);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }
    }

    public class Player{
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name, List<Card> hand = null)
        {
            //I don't know why this worked.. something along the lines on initilizing a list even if it is null. But I had to have this.
            hand = hand ?? new List<Card>();
            Name = name;
            Hand = hand;
        }
        public void draw(Deck deck)
        {
            Card card = deck.cards[0];
            Hand.Add(card);
            deck.cards.RemoveAt(0);
            
        }
        public Card discard(int card)
        {
            if ( Hand[card] != null )
            {
                Card temp = Hand[card];
                Hand.RemoveAt(card);
                return temp;
            }
            else
            {
                return null;
            }
            
        }

    }

}