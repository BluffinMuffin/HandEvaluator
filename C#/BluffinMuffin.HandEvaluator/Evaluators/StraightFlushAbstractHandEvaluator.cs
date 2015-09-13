using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class StraightFlushAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.StraightFlush;

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Suit).ToArray();

            var flush = groupedCards.FirstOrDefault(x => x.Count() >= 5);

            if (flush == null)
                return null;

            var distinctCards = flush.GroupBy(x => x.Value).Select(g => g.First()).OrderByDescending(x => x.Value).ToArray();

            if (distinctCards.Length < 5)
                return null;

            var ace = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Ace);
            var two = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Two);
            var three = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Three);
            var four = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Four);
            var five = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Five);

            if (ace != null && two != null && three != null && four != null && five != null)
            {
                res.Cards.Add(new[] { five, four, three, two, ace });
                return res;
            }

            for (var i = 0; (i + 4) < distinctCards.Length; ++i)
            {
                if ((int)distinctCards[i].Value - (int)distinctCards[i + 4].Value == 4)
                {
                    res.Cards.Add(distinctCards.Skip(i).Take(5).ToArray());
                    return res;
                }

            }
            return null;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Straight Flush with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}]";
        }
    }
}
