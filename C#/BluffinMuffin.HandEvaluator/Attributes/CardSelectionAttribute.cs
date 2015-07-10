using System;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.Attributes
{
    public class CardSelectionAttribute : Attribute
    {
        public CardSelectionEnum Selector { get; private set; }

        public CardSelectionAttribute(CardSelectionEnum selector)
        {
            Selector = selector;
        }
    }
}
