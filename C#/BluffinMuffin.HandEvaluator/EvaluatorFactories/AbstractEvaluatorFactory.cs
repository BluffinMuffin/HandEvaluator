using System.Collections.Generic;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public abstract class AbstractEvaluatorFactory
    {
        public abstract IEnumerable<AbstractHandEvaluator> Evaluators { get; }
    }
}
