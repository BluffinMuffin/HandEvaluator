using BluffinMuffin.HandEvaluator.Enums;

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
