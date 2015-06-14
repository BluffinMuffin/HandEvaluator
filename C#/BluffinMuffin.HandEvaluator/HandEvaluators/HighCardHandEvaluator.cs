using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandEvaluators
{
    public class HighCardHandEvaluator : HandEvaluator
    {
        public override HandEnum HandType
        {
            get {return HandEnum.HighCard;}
        }

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            foreach(var c in cards.OrderByDescending(x => x).Take(5))
                res.Cards.Add(new []{c});

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return String.Format("High Card with cards [{0}]", String.Join(", ",res.Cards.Select(x => x[0].ToString())));
        }
    }
}
