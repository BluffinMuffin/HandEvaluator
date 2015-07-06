using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public static class HandEvaluators
    {
        private static AbstractHandEvaluator[] m_Evaluators;
        public static HandEvaluationResult Evaluate(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluatorTypeEnum type)
        {
            if (type == EvaluatorTypeEnum.TexasHoldEm)
            {
                if (m_Evaluators == null)
                    m_Evaluators = typeof (AbstractHandEvaluator).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof (AbstractHandEvaluator)) && !t.IsAbstract).Select(t => (AbstractHandEvaluator) Activator.CreateInstance(t)).ToArray();

                var pCards = playerCards.Union(communityCards).Select(c => new PlayingCard(c)).ToArray();

                return m_Evaluators.Select(x => x.Evaluation(pCards)).Where(x => x != null).Max();
            }
            return null;
        }

        public static IEnumerable<IGrouping<int, EvaluatedCardHolder>> Evaluate( EvaluatorTypeEnum type, params IStringCardsHolder[] cardHolders)
        {
            var holders = cardHolders.Select(x => new EvaluatedCardHolder(x,type));
            var orderedHolders = holders.OrderByDescending(p => p.Evaluation).ToArray();
            var currentRank = 0;
            EvaluatedCardHolder lastHolder = null;
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
