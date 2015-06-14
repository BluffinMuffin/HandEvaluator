using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandEvaluators
{
    public class OnePairHandEvaluator : HandEvaluator
    {
        public override HandEnum HandType
        {
            get {return HandEnum.OnePair;}
        }

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.OrderByDescending(x => x.Value).GroupBy(x => x.Value).ToArray();

            var pairs = groupedCards.Where(x => x.Count() == 2).ToArray();

            if (!pairs.Any())
                return null;

            var pair = pairs.First();

            res.Cards.Add(pair.ToArray());

            foreach (var c in cards.Except(pair).OrderByDescending(x => x.Value).Take(3))
                res.Cards.Add(new []{c});

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return String.Format("One Pair with cards [({0}), {1}]", String.Join(", ",res.Cards[0].Select(x => x.ToString())), String.Join(", ",res.Cards.Skip(1).Select(x => x[0].ToString())));
        }
    }
}
