using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandRankers
{
    public class FlushBeatsFullHouseHandRanker : BasicHandRanker
    {
        public override int Rank(HandEnum hand)
        {
            var h = hand;
            switch (hand)
            {
                case HandEnum.Flush:
                    h = HandEnum.FullHouse;
                    break;
                case HandEnum.FullHouse:
                    h = HandEnum.Flush;
                    break;
            }
            return base.Rank(h);
        }
    }
}
