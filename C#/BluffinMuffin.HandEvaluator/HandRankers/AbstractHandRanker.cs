using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandRankers
{
    public abstract class AbstractHandRanker
    {
        public abstract int Rank(HandEnum hand);
    }
}
