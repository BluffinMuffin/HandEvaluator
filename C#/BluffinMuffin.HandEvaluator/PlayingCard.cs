using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Exceptions;

namespace BluffinMuffin.HandEvaluator
{
    public class PlayingCard : IComparable<PlayingCard>
    {
        private static readonly string[] VALUES = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static readonly string[] SUITS = { "H", "D", "C", "S" };

        public NominalValueEnum Value { get; private set; }
        public SuitEnum Suit { get; set; }

        public PlayingCard(NominalValueEnum value, SuitEnum suit)
        {
            if (!Enum.IsDefined(typeof(NominalValueEnum), value))
                throw new NotInEnumScopeException<NominalValueEnum>(value);

            if (!Enum.IsDefined(typeof(SuitEnum), suit))
                throw new NotInEnumScopeException<SuitEnum>(suit);

            Value = value;
            Suit = suit;
        }

        public PlayingCard(string stringRepresentation)
        {
            if (stringRepresentation.Length < 2 || stringRepresentation.Length > 3)
                throw new InvalidStringRepresentationException(stringRepresentation, "Length");
            string value = stringRepresentation.Remove(stringRepresentation.Length - 1).ToUpper();
            if (!VALUES.Contains(value))
                throw new InvalidStringRepresentationException(stringRepresentation,"Nominal Value");
            Value = (NominalValueEnum) Array.IndexOf(VALUES, value);

            string suit = stringRepresentation.Substring(stringRepresentation.Length - 1, 1).ToUpper();
            if (!SUITS.Contains(suit))
                throw new InvalidStringRepresentationException(stringRepresentation, "Suit");
            Suit = (SuitEnum)Array.IndexOf(SUITS, suit);
        }
        public override string ToString()
        {
            return String.Format("{0}{1}", VALUES[(int) Value], SUITS[(int) Suit]);
        }

        public int CompareTo(PlayingCard other)
        {
            return ((int)Value).CompareTo((int)other.Value);
        }
    }
}
