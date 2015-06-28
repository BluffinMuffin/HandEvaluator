﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.HandEvaluators
{
    public class TwoPairsHandEvaluator : HandEvaluator
    {
        public override HandEnum HandType
        {
            get {return HandEnum.TwoPairs;}
        }

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.OrderByDescending(x => x.Value).GroupBy(x => x.Value).ToArray();

            var pairs = groupedCards.Where(x => x.Count() == 2).ToArray();

            if (pairs.Length < 2)
                return null;

            var higherPair = pairs.First();

            res.Cards.Add(higherPair.ToArray());

            var lowerPair = pairs.Skip(1).First();

            res.Cards.Add(lowerPair.ToArray());

            res.Cards.Add(new []{cards.Except(higherPair).Except(lowerPair).OrderByDescending(x => x).First()});

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return String.Format("Two Pairs with cards [({0}), ({1}), {2}]", String.Join(", ", res.Cards[0].Select(x => x.ToString())), String.Join(", ", res.Cards[1].Select(x => x.ToString())), String.Join(", ", res.Cards.Skip(2).Select(x => x[0].ToString())));
        }
    }
}