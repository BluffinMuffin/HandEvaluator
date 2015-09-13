using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;
using static System.Math;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class TwoPairsAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.TwoPairs;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 4)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.OrderByDescending(x => x).GroupBy(x => x.Value).ToArray();

            var pairs = groupedCards.Where(x => x.Count() == 2).ToArray();

            if (pairs.Length < 2)
                return null;

            var higherPair = pairs.First();

            res.Cards.Add(higherPair.OrderByDescending(x => x).ToArray());

            var lowerPair = pairs.Skip(1).First();

            res.Cards.Add(lowerPair.OrderByDescending(x => x).ToArray());

            var remaining = cards.Except(higherPair).Except(lowerPair).OrderByDescending(x => x);

            if (remaining.Any())
                remaining.Take(Min(1, remaining.Count())).ToList().ForEach(c => res.Cards.Add(new[] { c }));

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Two Pairs with cards [{Join(", ", res.Cards.Select(x => x.Length > 1 ? $"({Join(", ", x.Select(c => c.ToString()))})" : x[0].ToString()))}]";
        }
    }
}
