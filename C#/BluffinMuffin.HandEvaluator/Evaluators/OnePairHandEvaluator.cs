using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.Math;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class OnePairHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.OnePair;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 2)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.OrderByDescending(x => x).GroupBy(x => x.Value).ToArray();

            var pairs = groupedCards.Where(x => x.Count() == 2).ToArray();

            if (!pairs.Any())
                return null;

            var pair = pairs.First();

            res.Cards.Add(pair.OrderByDescending(x => x).ToArray());

            var remaining = cards.Except(pair).OrderByDescending(x => x);

            if (remaining.Any())
                remaining.Take(Min(3,remaining.Count())).ToList().ForEach(c => res.Cards.Add(new[] { c }));

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"One Pair with cards [{Join(", ", res.Cards.Select(x => x.Length > 1 ? $"({Join(", ", x.Select(c => c.ToString()))})" : x[0].ToString()))}]";
        }
    }
}
