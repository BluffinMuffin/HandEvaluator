using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using static System.Math;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class HighCardAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType => HandEnum.HighCard;

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 1)
                return null;

            var res = new HandEvaluationResult(this);

            foreach(var c in cards.OrderByDescending(x => x).Take(Min(5,cards.Length)))
                res.Cards.Add(new []{c});

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return $"High Card with cards [{Join(", ", res.Cards.Select(x => x[0].ToString()))}]";
        }
    }
}
