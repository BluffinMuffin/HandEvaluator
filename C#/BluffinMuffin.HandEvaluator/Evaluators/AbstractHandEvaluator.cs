using System;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.Evaluators
{
    public abstract class AbstractHandEvaluator
    {
        public abstract HandEnum HandType { get; }

        internal abstract HandEvaluationResult Evaluation(PlayingCard[] cards, EvaluationParams parms);

        public abstract String ResultToString(HandEvaluationResult res);
    }
}
