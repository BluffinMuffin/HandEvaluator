using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandRankers
{
    public class BasicHandRanker : AbstractHandRanker
    {
        public override int Rank(HandEnum hand)
        {
            return (int) hand;
        }
    }
}
