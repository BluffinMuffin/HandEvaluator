using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class StraightHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.Straight;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards, EvaluationParams parms)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this, parms);

            var distinctCards = cards.GroupBy(x => x.Value).Select(g => g.First()).OrderByDescending(x => x).ToArray();

            if (distinctCards.Length < 5)
                return null;

            for (int i = 0; (i + 4) < distinctCards.Length; ++i)
            {
                if ((int) distinctCards[i].Value - (int) distinctCards[i + 4].Value == 4)
                {
                    res.Cards.Add(distinctCards.Skip(i).Take(5).ToArray());
                    return res;
                }

            }

            //Check for A-2-3-4-5 only if no better straight have been found
            var ace = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Ace);
            var two = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Two);
            var three = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Three);
            var four = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Four);
            var five = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Five);

            if (ace == null || two == null || three == null || four == null || five == null) return null;

            res.Cards.Add(new[] { five, four, three, two, ace });
            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Straight with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}]";
        }
    }
}
