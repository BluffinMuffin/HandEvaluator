using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluationParams
    {
        public CardSelectionEnum CardSelection { get; set; } = CardSelectionEnum.AllPlayerAndAllCommunity;

        public bool UseSuitRanking { get; set; } = false;
    }
}
