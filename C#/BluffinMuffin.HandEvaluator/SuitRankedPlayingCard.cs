using System;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Exceptions;

namespace BluffinMuffin.HandEvaluator
{
    public class SuitRankedPlayingCard : PlayingCard
    {
        public SuitRankedPlayingCard(NominalValueEnum value, SuitEnum suit)
            : base(value, suit)
        {
        }
        public SuitRankedPlayingCard(string stringRepresentation)
            : base(stringRepresentation)
        {
        }

        public override int CompareTo(PlayingCard other)
        {
            var baseValue = base.CompareTo(other);
            return baseValue == 0 ? ((int) Suit).CompareTo((int) other.Suit) : baseValue;
        }
    }
}
