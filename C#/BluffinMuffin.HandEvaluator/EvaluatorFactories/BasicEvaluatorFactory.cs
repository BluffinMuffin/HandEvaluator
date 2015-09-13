using System.Collections.Generic;
using BluffinMuffin.HandEvaluator.Evaluators;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public class BasicEvaluatorFactory : AbstractEvaluatorFactory
    {
        public override IEnumerable<AbstractHandEvaluator> Evaluators => new AbstractHandEvaluator[]
        {
            new HighCardHandEvaluator(),
            new OnePairHandEvaluator(),
            new TwoPairsHandEvaluator(),
            new ThreeOfAKindHandEvaluator(),
            new StraightHandEvaluator(),
            new FlushHandEvaluator(),
            new FullHouseHandEvaluator(),
            new FourOfAKindHandEvaluator(),
            new StraightFlushHandEvaluator(),
        };
    }
}
