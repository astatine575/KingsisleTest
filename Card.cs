using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsisleTest
{
    class Card
    {
        public enum Values { UNINITIALIZED = 0,
                      ACE = 1,
                      TWO = 2,
                      THREE = 3,
                      FOUR = 4,
                      FIVE = 5,
                      SIX = 6,
                      SEVEN = 7,
                      EIGHT = 8,
                      NINE = 9,
                      TEN = 10,
                      JACK = 11,
                      QUEEN = 12,
                      KING = 13,
                      MAXVALUE
        };

        public enum Suites
        {
            UNINITIALIZED = 0,
            HEARTS,
            DIAMONDS,
            CLUBS,
            SPADES,
            MAXVALUE
        };

        protected Values m_value;
        protected Suites m_suite;

        Card()
        {
            m_value = Values.UNINITIALIZED;
            m_suite = Suites.UNINITIALIZED;
        }

        Card(Values value, Suites suite)
        {
            m_value = value;
            m_suite = suite;
        }

        public Values getValue()
        {
            return m_value;
        }

        public void setValue(Values value)
        {
            m_value = value;
        }

        public Suites getSuite()
        {
            return m_suite;
        }

        public void setSuite(Suites suite)
        {
            m_suite = suite;
        }

        public String toString()
        {
            String value;
            switch(m_value)
            {
                case Values.UNINITIALIZED:
                    value = "Nothing";
                    break;
                case Values.ACE:
                    value = "Ace";
                    break;
                case Values.TWO:
                    value = "2";
                    break;
                case Values.THREE:
                    value = "3";
                    break;
                case Values.FOUR:
                    value = "4";
                    break;
                case Values.FIVE:
                    value = "5";
                    break;
                case Values.SIX:
                    value = "6";
                    break;
                case Values.SEVEN:
                    value = "7";
                    break;
                case Values.EIGHT:
                    value = "8";
                    break;
                case Values.NINE:
                    value = "9";
                    break;
                case Values.TEN:
                    value = "10";
                    break;
                case Values.JACK:
                    value = "Jack";
                    break;
                case Values.QUEEN:
                    value = "Queen";
                    break;
                case Values.KING:
                    value = "King";
                    break;
                default:
                    value = "What?!";
                    break;
            }

            String suite;
            switch (m_suite)
            {
                case Suites.UNINITIALIZED:
                    suite = "Nothing";
                    break;
                case Suites.HEARTS:
                    suite = "Hearts";
                    break;
                case Suites.DIAMONDS:
                    suite = "Diamonds";
                    break;
                case Suites.CLUBS:
                    suite = "Clubs";
                    break;
                case Suites.SPADES:
                    suite = "Spades";
                    break;
                default:
                    suite = "What?!";
                    break;
            }

            return "" + value + " of " + suite;
        }
    }
}
