using System.Collections.Generic;
using BluffinMuffin.HandEvaluator.Evaluators;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public class NoStraightNoFlushEvaluatorFactory : AbstractEvaluatorFactory
    {
        public override IEnumerable<AbstractHandEvaluator> Evaluators => new AbstractHandEvaluator[]
        {
            new HighCardAbstractHandEvaluator(),
            new OnePairAbstractHandEvaluator(),
            new TwoPairsAbstractHandEvaluator(),
            new ThreeOfAKindAbstractHandEvaluator(),
            new FullHouseAbstractHandEvaluator(),
            new FourOfAKindAbstractHandEvaluator(),
        };
    }
}
