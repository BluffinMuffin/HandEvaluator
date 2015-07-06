using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.Attributes
{
    public class EvaluatorTypesAttribute : Attribute
    {
        public EvaluatorTypeEnum[] Evaluators { get; private set; }

        public EvaluatorTypesAttribute(params EvaluatorTypeEnum[] evaluators)
        {
            Evaluators = evaluators;
        }
    }
}
