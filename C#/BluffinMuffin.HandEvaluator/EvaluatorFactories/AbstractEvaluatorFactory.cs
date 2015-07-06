using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.HandEvaluator.EvaluatorFactories
{
    public abstract class AbstractEvaluatorFactory
    {
        public abstract IEnumerable<AbstractHandEvaluator> Evaluators { get; } 
    }
}
