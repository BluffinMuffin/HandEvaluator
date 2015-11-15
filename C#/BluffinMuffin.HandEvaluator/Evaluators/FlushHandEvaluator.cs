using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class FlushHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.Flush;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards, EvaluationParams parms)
        {
            var res = new HandEvaluationResult(this, parms);

            var flush = GetPotentialFlushes(cards).FirstOrDefault();

            if (flush == null)
                return null;

            foreach (var c in flush.OrderByDescending(x => x).Take(5))
                res.Cards.Add(new[] {c});

            return res;
        }

        public static IEnumerable<PlayingCard[]> GetPotentialFlushes(PlayingCard[] cards)
        {
            if (cards.Length >= 5)
            {
                var groupedCards = cards.GroupBy(x => x.Suit).ToArray();

                foreach (var g in groupedCards.Where(x => x.Count() >= 5))
                    yield return g.ToArray();
            }
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Flush with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}]";
        }
    }
}
