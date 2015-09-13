using System.Collections.Generic;
using BluffinMuffin.HandEvaluator.Evaluators;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public class SingleEvaluatorFactory<T> : AbstractEvaluatorFactory
        where T: AbstractHandEvaluator, new()
    {
        public override IEnumerable<AbstractHandEvaluator> Evaluators => new AbstractHandEvaluator[] {new T()};
    }
}
