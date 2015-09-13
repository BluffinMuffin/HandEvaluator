using System.Collections.Generic;
using BluffinMuffin.HandEvaluator.Evaluators;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public abstract class AbstractEvaluatorFactory
    {
        public abstract IEnumerable<AbstractHandEvaluator> Evaluators { get; }
    }
}
