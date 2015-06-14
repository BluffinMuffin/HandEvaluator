using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandEvaluators
{
    public class FourOfAKindHandEvaluator : HandEvaluator
    {
        public override HandEnum HandType
        {
            get {return HandEnum.FourOfAKind;}
        }

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Value).ToArray();

            var foursomes = groupedCards.Where(x => x.Count() == 4).OrderByDescending(x => x.Key).ToArray();

            if (foursomes.Length == 0)
                return null;

            var foursome = foursomes.First();

            res.Cards.Add(foursome.ToArray());

            res.Cards.Add(cards.Except(foursome).OrderByDescending(x => x).Take(1).ToArray());

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return String.Format("Four Of A Kind with cards [({0}), {1}]", String.Join(", ", res.Cards[0].Select(x => x.ToString())), String.Join(", ", res.Cards.Skip(1).Select(x => x[0].ToString())));
        }
    }
}
