using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluationParams
    {
        public CardSelectionEnum CardSelection { get; set; } = CardSelectionEnum.AllPlayerAndAllCommunity;

        public bool UseSuitRanking { get; set; } = false;

        public AbstractEvaluatorFactory EvaluatorFactory { get; set; } = new BasicEvaluatorFactory();
    }
}
