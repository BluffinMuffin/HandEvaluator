using System.Collections.Generic;
using BluffinMuffin.HandEvaluator.Evaluators;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public class NoStraightNoFlushEvaluatorFactory : AbstractEvaluatorFactory
    {
        public override IEnumerable<AbstractHandEvaluator> Evaluators => new AbstractHandEvaluator[]
        {
            new HighCardHandEvaluator(),
            new OnePairHandEvaluator(),
            new TwoPairsHandEvaluator(),
            new ThreeOfAKindHandEvaluator(),
            new FullHouseHandEvaluator(),
            new FourOfAKindHandEvaluator(),
        };
    }
}
