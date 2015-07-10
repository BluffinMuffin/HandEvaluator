using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluatedCardHolder
    {
        public IStringCardsHolder CardsHolder { get; private set; }
        public HandEvaluationResult Evaluation { get; private set; }
        public int Rank { get; internal set; }

        public EvaluatedCardHolder(IStringCardsHolder holder, CardSelectionEnum selection)
        {
            CardsHolder = holder;
            Evaluation = HandEvaluators.Evaluate(selection, holder.PlayerCards, holder.CommunityCards);
            Rank = int.MaxValue;
        }
    }
}
