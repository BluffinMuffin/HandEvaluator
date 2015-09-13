using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class FullHouseAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.FullHouse;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Value).ToArray();

            var triplet = groupedCards.FirstOrDefault(x => x.Count() == 3);

            var pair = groupedCards.FirstOrDefault(x => x.Count() == 2);

            if (triplet == null || pair == null)
                return null;

            res.Cards.Add(triplet.OrderByDescending(x => x).ToArray());

            res.Cards.Add(pair.OrderByDescending(x => x).ToArray());

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Full House with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}, {Join(", ", res.Cards[1].Select(x => x.ToString()))}]";
        }
    }
}
