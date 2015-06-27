using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public abstract class HandEvaluator
    {
        public abstract HandEnum HandType { get; }

        private static HandEvaluator[] m_Evaluators;
        public static HandEvaluationResult Evaluate(params string[] cards)
        {
            if (m_Evaluators == null)
                m_Evaluators = typeof(HandEvaluator).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(HandEvaluator)) && !t.IsAbstract).Select(t => (HandEvaluator)Activator.CreateInstance(t)).ToArray();

            var pCards = cards.Select(c => new PlayingCard(c)).ToArray();

            return m_Evaluators.Select(x => x.Evaluation(pCards)).Where(x => x != null).Max();
        }
        public static IEnumerable<IGrouping<int, EvaluatedCardHolder>> Evaluate(params IStringCardsHolder[] cardHolders)
        {
            var holders = cardHolders.Select(x => new EvaluatedCardHolder(x));
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

        public abstract HandEvaluationResult Evaluation(PlayingCard[] cards);

        public abstract String ResultToString(HandEvaluationResult res);
    }
}
