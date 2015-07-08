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
                foreach (Type t in typeof (AbstractEvaluatorFactory).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof (AbstractEvaluatorFactory)) && !x.IsAbstract))
                {
                    var att = t.GetCustomAttribute<EvaluatorTypesAttribute>();
                    if (att != null && att.Evaluators != null && att.Evaluators.Any())
                        foreach (var ev in att.Evaluators)
                            m_Factories.Add(ev, (AbstractEvaluatorFactory) Activator.CreateInstance(t));
                }
            }

            if (m_Factories.ContainsKey(type))
            {
                if (type == EvaluatorTypeEnum.OmahaHoldEm)
                {
                    var pc = playerCards.ToArray();
                    var cc = communityCards.ToArray();
                    var results = new List<HandEvaluationResult>();
                    for (int i = 0; i < pc.Length; ++i)
                        for (int j = i + 1; j < pc.Length; ++j)
                            for (int a = 0; a < cc.Length; ++a)
                                for (int b = a + 1; b < cc.Length; ++b)
                                    for (int c = b + 1; c < cc.Length; ++c)
                                    {
                                        var pCards = new[] {pc[i], pc[j], cc[a], cc[b], cc[c]}.Select(x => new PlayingCard(x)).ToArray();
                                        results.Add(m_Factories[type].Evaluators.Select(x => x.Evaluation(pCards)).Where(x => x != null).Max());
                                    }
                    return results.Max();
                }
                else
                {
                    var pCards = playerCards.Union(communityCards).Select(c => new PlayingCard(c)).ToArray();
                    return m_Factories[type].Evaluators.Select(x => x.Evaluation(pCards)).Where(x => x != null).Max();
                }
            }
            return null;
        }

        public static IEnumerable<IGrouping<int, EvaluatedCardHolder>> Evaluate(EvaluatorTypeEnum type, params IStringCardsHolder[] cardHolders)
        {
            var holders = cardHolders.Select(x => new EvaluatedCardHolder(x, type));
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
