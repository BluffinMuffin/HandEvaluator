using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class StraightFlushHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.StraightFlush;

        internal override HandEvaluationResult Evaluation(PlayingCard[] cards, EvaluationParams parms)
        {
            var res = new HandEvaluationResult(this, parms);

            foreach (var straight in FlushHandEvaluator.GetPotentialFlushes(cards,parms)
                .Select(flush => flush.GroupBy(x => x.Value).Select(g => g.First()).OrderByDescending(x => x).ToArray())
                .Select(distinctCards => distinctCards.GroupBy(x => x.Value).Select(g => g.First()).OrderByDescending(x => x).ToArray())
                .TakeWhile(distinctCards => distinctCards.Length >= 5)
                .Select(distinctCards => StraightHandEvaluator.GetBestStraight(distinctCards, parms))
                .Where(straight => straight != null))
            {
                res.Cards.Add(straight);
                return res;
            }
            return null;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"Straight Flush with cards [{Join(", ", res.Cards[0].Select(x => x.ToString()))}]";
        }
    }
}
