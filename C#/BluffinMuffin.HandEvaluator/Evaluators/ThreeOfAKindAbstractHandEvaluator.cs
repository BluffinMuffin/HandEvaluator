﻿using System;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public class ThreeOfAKindAbstractHandEvaluator : AbstractHandEvaluator
    {
        public override HandEnum HandType
        {
            get {return HandEnum.ThreeOfAKind;}
        }

        public override HandEvaluationResult Evaluation(PlayingCard[] cards)
        {
            if (cards.Length < 5)
                return null;

            var res = new HandEvaluationResult(this);

            var groupedCards = cards.GroupBy(x => x.Value).ToArray();

            var triplets = groupedCards.Where(x => x.Count() == 3).OrderByDescending(x => x.Key).ToArray();

            if (triplets.Length == 0)
                return null;

            var triplet = triplets.First();

            res.Cards.Add(triplet.ToArray());

            res.Cards.AddRange(cards.Except(triplet).OrderByDescending(x => x).Take(2).Select(x => new []{x}));

            return res;
        }

        public override string ResultToString(HandEvaluationResult res)
        {
            return String.Format("Three Of A Kind with cards [({0}), {1}]", String.Join(", ", res.Cards[0].Select(x => x.ToString())), String.Join(", ", res.Cards.Skip(1).Select(x => x[0].ToString())));
        }
    }
}