using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class FourOfAKindAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.FourOfAKind;

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 4)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Value).ToArray();

            var foursomes = groupedCards.Where(x => x.Count() == 4).OrderByDescending(x => x.Key).ToArray();

            if (foursomes.Length == 0)
                return null;

            var foursome = foursomes.First();

            res.Cards.Add(foursome.ToArray());

            var remaining = cards.Except(foursome).OrderByDescending(x => x);

            if (remaining.Any())
                res.Cards.Add(remaining.Take(1).ToArray());

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Four Of A Kind with cards [{Join(", ",res.Cards.Select(x => x.Length > 1 ? $"({Join(", ", x.Select(c => c.ToString()))})" : x[0].ToString()))}]";
        }
    }
}
