using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class StraightAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.Straight;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var distinctCards = cards.GroupBy(x => x.Value).Select(g => g.First()).OrderByDescending(x => x).ToArray();

            if (distinctCards.Length < 5)
                return null;
            
            PlayingCard ace = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Ace);
            PlayingCard two = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Two);
            PlayingCard three = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Three);
            PlayingCard four = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Four);
            PlayingCard five = distinctCards.FirstOrDefault(x => x.Value == NominalValueEnum.Five);

            if (ace != null && two != null && three != null && four != null && five != null)
            {
                res.Cards.Add(new[] {five, four, three, two, ace});
                return res;
            }

            for (int i = 0; (i + 4) < distinctCards.Length; ++i)
            {
                if ((int) distinctCards[i].Value - (int) distinctCards[i + 4].Value == 4)
                {
                    res.Cards.Add(distinctCards.Skip(i).Take(5).ToArray());
                    return res;
                }

            }
            return null;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Straight with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}]";
        }
    }
}
