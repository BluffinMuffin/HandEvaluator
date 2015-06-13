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

        protected override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            HandEvaluationResult res = new HandEvaluationResult(this);

            IGrouping<NominalValueEnum, PlayingCard>[] groupedCards = cards.GroupBy(x => x.Value).ToArray();

            IGrouping<NominalValueEnum, PlayingCard>[] pairs = groupedCards.Where(x => x.Count() == 2).ToArray();

            if (pairs.Length != 1)
                return null;

            IGrouping<NominalValueEnum, PlayingCard> pair = pairs.Single();

            res.Cards.Add(pair.ToArray());

            foreach (PlayingCard c in cards.Except(pair).OrderByDescending(x => x).Take(3))
                res.Cards.Add(new []{c});

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return String.Format("One Pair with cards [({0}) , {1}]", String.Join(", ",res.Cards[0].Select(x => x.ToString())), String.Join(", ",res.Cards.Skip(1).Select(x => x[0].ToString())));
        }
    }
}
