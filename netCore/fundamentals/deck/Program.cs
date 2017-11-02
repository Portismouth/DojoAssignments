using System;

namespace deck
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create deck
            Deck deck = new Deck();

            //Deal deck to test
            for (int i = 0; i < 52; i ++)
            {
                Card deal = deck.deal();
                Console.WriteLine("{0} of {1}", deal.stringVal, deal.Suit);
            }

            // // reset deck to unshuffled and deal first card to check
            deck.reset();
            Card newCard = deck.deal();
            Console.WriteLine("{0} of {1}", newCard.stringVal, newCard.Suit);

            // //shuffle cards and deal deck to test
            deck.shuffle();
            for (int i = 0; i < 10; i ++)
            {
                Card deal = deck.deal();
                Console.WriteLine("{0} of {1}", deal.stringVal, deal.Suit);
            }

            //Create player and Draw card for mitchell and check
            Player mitchell = new Player("Mitchell");
            mitchell.draw(deck);
            foreach ( Card card in mitchell.Hand )
            {
                Console.WriteLine("{0} of {1} in Mitchell's hand", card.stringVal, card.Suit);
            }

            // Discard and check. console should print hand is empy since we only added one to hand earlier
            Card discard = mitchell.discard(0);
            Console.WriteLine("Discarded: {0} of {1}", discard.stringVal, discard.Suit);
            if (mitchell.Hand.Count == 0)
            {
                Console.WriteLine("Hand is empty");
            }
        }
    }
}
