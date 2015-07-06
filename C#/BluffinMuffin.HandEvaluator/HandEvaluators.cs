using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BluffinMuffin.HandEvaluator.Attributes;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;

namespace BluffinMuffin.HandEvaluator
{
    public static class HandEvaluators
    {
        private static Dictionary<EvaluatorTypeEnum, AbstractEvaluatorFactory> m_Factories;
        public static HandEvaluationResult Evaluate(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluatorTypeEnum type)
        {
            if (m_Factories == null)
            {
                m_Factories = new Dictionary<EvaluatorTypeEnum, AbstractEvaluatorFactory>();
                foreach (Type t in typeof(AbstractEvaluatorFactory).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(AbstractEvaluatorFactory)) && !x.IsAbstract))
                {
                    var att = t.GetCustomAttribute<EvaluatorTypesAttribute>();
                    if(att != null && att.Evaluators != null && att.Evaluators.Any())
                        foreach(var ev in att.Evaluators)
                            m_Factories.Add(ev, (AbstractEvaluatorFactory)Activator.CreateInstance(t));
                }
            }

            if(m_Factories.ContainsKey(type))
            {
                var pCards = playerCards.Union(communityCards).Select(c => new PlayingCard(c)).ToArray();

                return m_Factories[type].Evaluators.Select(x => x.Evaluation(pCards)).Where(x => x != null).Max();
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
