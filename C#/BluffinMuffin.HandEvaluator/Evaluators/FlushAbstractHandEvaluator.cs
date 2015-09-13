using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class FlushAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.Flush;

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Suit).ToArray();

            var flush = groupedCards.FirstOrDefault(x => x.Count() >= 5);

            if (flush == null)
                return null;

            foreach (var c in flush.OrderByDescending(x => x).Take(5))
                res.Cards.Add(new[] {c});

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Flush with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}]";
        }
    }
}
