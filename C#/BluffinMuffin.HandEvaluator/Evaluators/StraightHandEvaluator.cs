using System.Collections.Generic;
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
            var res = new HandEvaluationResult(this, parms);

            var straight = GetBestStraight(cards.GroupBy(x => x.Value).Select(g => g.First()).OrderByDescending(x => x).ToArray(), parms);

            if (straight == null) return null;

            res.Cards.Add(straight);
            return res;
        }

        public static PlayingCard[] GetBestStraight(PlayingCard[] distinctCards, EvaluationParams parms)
        {
            return GetPotentialHighStraights(distinctCards, parms).Concat(GetPotentialLowStraights(distinctCards, parms)).OrderByDescending(x => x[0]).FirstOrDefault();
        }

        public static IEnumerable<PlayingCard[]> GetPotentialHighStraights(PlayingCard[] distinctCards, EvaluationParams parms)
        {
            if (distinctCards.Length < 5)
                yield break;

            for (var i = 0; (i + 4) < distinctCards.Length; ++i)
                if ((int)distinctCards[i].Value - (int)distinctCards[i + 4].Value == 4)
                    yield return distinctCards.Skip(i).Take(5).ToArray();
        }

        public static IEnumerable<PlayingCard[]> GetPotentialLowStraights(PlayingCard[] distinctCards, EvaluationParams parms)
        {
            if (!parms.UseAceForLowStraight)
                yield break;

            //Check for A-2-3-4-5 only if no better straight have been found
            var ace = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Ace);
            var two = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Two);
            var three = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Three);
            var four = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Four);
            var five = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Five);

            if (ace == null || two == null || three == null || four == null || five == null)
                yield break;

            yield return new[] { five, four, three, two, ace };
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Straight with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}]";
        }
    }
}
