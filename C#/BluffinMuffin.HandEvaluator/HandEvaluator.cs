using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public abstract class HandEvaluator
    {
        public abstract HandEnum HandType { get; }

        private static HandEvaluator[] m_Evaluators;
        public static HandEvaluationResult Evaluate(string[] cards)
        {
            if (m_Evaluators == null)
                m_Evaluators = typeof (HandEvaluator).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof (HandEvaluator)) && !t.IsAbstract).Select(t => (HandEvaluator) Activator.CreateInstance(t)).ToArray();
            
            PlayingCard[] pCards = cards.Select(c => new PlayingCard(c)).ToArray();
            
            return m_Evaluators.Select(x => x.Evaluation(pCards)).Where(x => x != null).Max();
        }

        protected abstract HandEvaluationResult Evaluation(PlayingCard[] cards);

        public abstract String ResultToString(HandEvaluationResult res);
    }
}
