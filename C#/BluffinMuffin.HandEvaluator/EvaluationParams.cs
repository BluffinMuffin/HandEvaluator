using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Selectors;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluationParams
    {
        public bool UseSuitRanking { get; set; } = false;

        public AbstractCardsSelector Selector { get; set; } = new UseAllCardsSelector();

        public AbstractEvaluatorFactory EvaluatorFactory { get; set; } = new BasicEvaluatorFactory();
    }
}
