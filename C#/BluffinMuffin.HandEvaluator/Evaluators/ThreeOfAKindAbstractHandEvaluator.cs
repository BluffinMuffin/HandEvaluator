using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;
using static System.Math;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class ThreeOfAKindAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.ThreeOfAKind;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 3)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Value).ToArray();

            var triplets = groupedCards.Where(x => x.Count() == 3).OrderByDescending(x => x.Key).ToArray();

            if (triplets.Length == 0)
                return null;

            var triplet = triplets.First();

            res.Cards.Add(triplet.OrderByDescending(x => x).ToArray());

            var remaining = cards.Except(triplet).OrderByDescending(x => x);

            if (remaining.Any())
                remaining.Take(Min(2, remaining.Count())).ToList().ForEach(c => res.Cards.Add(new[] { c }));

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Three Of A Kind with cards [{Join(", ", res.Cards.Select(x => x.Length > 1 ? $"({Join(", ", x.Select(c => c.ToString()))})" : x[0].ToString()))}]";
        }
    }
}
