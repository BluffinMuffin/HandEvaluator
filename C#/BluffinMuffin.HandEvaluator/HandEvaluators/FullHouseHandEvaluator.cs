using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandEvaluators
{
    public class FullHouseHandEvaluator : HandEvaluator
    {
        public override HandEnum HandType
        {
            get {return HandEnum.FullHouse;}
        }

        protected override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Value).ToArray();

            var triplet = groupedCards.FirstOrDefault(x => x.Count() == 3);

            var pair = groupedCards.FirstOrDefault(x => x.Count() == 2);

            if (triplet == null || pair == null)
                return null;

            res.Cards.Add(triplet.ToArray());

            res.Cards.Add(pair.ToArray());

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return String.Format("Full House with cards [{0},{1}]", String.Join(", ", res.Cards[0].Select(x => x.ToString())), String.Join(", ", res.Cards[1].Select(x => x.ToString())));
        }
    }
}
