using System;
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
