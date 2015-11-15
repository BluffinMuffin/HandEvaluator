using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Selectors;

namespace BluffinMuffin.HandEvaluator
{
    public static class HandEvaluators
    {
        public static HandEvaluationResult Evaluate(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluationParams parms = null)
        {
            var myParms = parms ?? new EvaluationParams();
            return myParms.Selector.SelectCards(playerCards, communityCards, myParms).Select(cards => myParms.EvaluatorFactory.Evaluators.Select(x => x.Evaluation(cards.ToArray(),myParms)).Where(x => x != null).Max()).Max();
        }

        public static IEnumerable<IGrouping<int, EvaluatedCardHolder<T>>> Evaluate<T>(IEnumerable<T> cardHolders, EvaluationParams parms = null) where T : class, IStringCardsHolder
        {
            var holders = cardHolders.Select(x => new EvaluatedCardHolder<T>(x, parms));
            var orderedHolders = holders.OrderByDescending(p => p.Evaluation).ToArray();
            var currentRank = 0;
            EvaluatedCardHolder<T> lastHolder = null;
            foreach (var h in orderedHolders.Where(h => h.Evaluation != null))
            {
                if (lastHolder != null && h.Evaluation.CompareTo(lastHolder.Evaluation) == 0)
                    h.Rank = lastHolder.Rank;
                else
                    h.Rank = ++currentRank;
                lastHolder = h;
            }
            return orderedHolders.GroupBy(x => x.Rank);
        }
    }
}
