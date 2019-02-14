using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsisleTest
{
    class Deck
    {
        public enum Decks
        {
            STANDARD52,

            MAXVALUE
        }

        protected List<Card> m_cards; //top of the deck is the end of the list, bottom is beginning

        public Deck() // initialize a blank deck
        {
            m_cards = new List<Card>();
        }

        public Deck(Decks deckEnum) // initialize a Deck based off of a standard template
        {
            m_cards = new List<Card>();
            SetDeck(deckEnum);
        }

        public Deck(Deck deckToCopy) // initialize a Deck based off of another deck (essentially a copy)
        {
            m_cards = new List<Card>();
        }

        public bool SetDeck(Decks deckEnum) // sets a deck to one of the standards in the enum Decks by calling the relevant method
        {
            switch (deckEnum)
            {
                case Decks.STANDARD52:
                    return SetStandard52();
                case Decks.MAXVALUE:
                default:
                    return false; // invalid value
            }
        }

        protected bool SetStandard52() // sets the deck to a normal 52 card deck
        {
            ClearDeck();
            for (Card.Suites suite = Card.Suites.UNINITIALIZED + 1; suite < Card.Suites.MAXVALUE; suite++)
            {
                for (Card.Values value = Card.Values.UNINITIALIZED + 1; value < Card.Values.MAXVALUE; value++)
                {
                    AddCard(new Card(value, suite));
                }
            }
            return true;
        }

        public void ClearDeck() // empties the deck
        {
            m_cards.Clear();
        }

        public void ShuffleDeck() // shuffles the deck based on Fisher-Yates shuffle
        {
            Random random = new Random();
            for (int i = 0; i < m_cards.Count-1; i++)
            {
                int j = random.Next(i,m_cards.Count);
                Card temp = m_cards[i];
                m_cards[i] = m_cards[j];
                m_cards[j] = temp;
            }
        }

        public void AddCard(Card card) // add a card to the top of the deck
        {
            InsertCard(card, m_cards.Count);
        }

        public void InsertCard(Card card, int i) // insert a card after the i'th card of the deck
        {
            if (i < 0 || i >= m_cards.Count)
            {
                Debug.WriteLine("inserting at out of bound card " + i + "");
                throw new IndexOutOfRangeException();
            }

            m_cards.Insert(i, card);
        }

        public Card PeekAtTopCard() // look at top card without removing from deck
        {
            return PeekAtCard(m_cards.Count - 1);
        }

        public Card PeekAtCard(int i) // look at card without removing from deck
        {
            if(i < 0 || i >= m_cards.Count)
            {
                Debug.WriteLine("Peeking at out of bound card "+i+"");
                throw new IndexOutOfRangeException();
            }

            return m_cards[i];
        }

        public Card DrawTopCard() // look at top card and remove from deck
        {
            return DrawCard(m_cards.Count - 1);
        }

        public Card DrawCard(int i) // look at card and remove from deck
        {
            if (i < 0 || i >= m_cards.Count)
            {
                Debug.WriteLine("Drawing out of bound card " + i + "");
                throw new IndexOutOfRangeException();
            }

            Card drawn = m_cards[i];
            m_cards.RemoveAt(i);
            return drawn;
        }

        override public String ToString()
        {
            String returnString = "";
            returnString += "Deck of "+m_cards.Count+" cards.\n";
            m_cards.ForEach(card => returnString += card.ToString()+ "\n");

            return returnString;
        }
    }
}
