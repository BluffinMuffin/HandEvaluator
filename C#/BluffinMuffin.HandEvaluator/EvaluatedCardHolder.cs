using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluatedCardHolder
    {
        public IStringCardsHolder CardsHolder { get;}
        public HandEvaluationResult Evaluation { get;}
        public int Rank { get; internal set; }
        public EvaluationParams Parms { get; }

        public EvaluatedCardHolder(IStringCardsHolder holder, EvaluationParams parms)
        {
            Parms = parms;
            CardsHolder = holder;
            Evaluation = HandEvaluators.Evaluate( holder.PlayerCards, holder.CommunityCards,parms);
            Rank = int.MaxValue;
        }
    }
}
