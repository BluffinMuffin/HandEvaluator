using System.Collections.Generic;
using BluffinMuffin.HandEvaluator.Evaluators;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public class BasicEvaluatorFactory : AbstractEvaluatorFactory
    {
        public override IEnumerable<AbstractHandEvaluator> Evaluators => new AbstractHandEvaluator[]
        {
            new HighCardAbstractHandEvaluator(),
            new OnePairAbstractHandEvaluator(),
            new TwoPairsAbstractHandEvaluator(),
            new ThreeOfAKindAbstractHandEvaluator(),
            new StraightAbstractHandEvaluator(),
            new FlushAbstractHandEvaluator(),
            new FullHouseAbstractHandEvaluator(),
            new FourOfAKindAbstractHandEvaluator(),
            new StraightFlushAbstractHandEvaluator(),
        };
    }
}
