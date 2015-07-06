using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluatedCardHolder
    {
        public IStringCardsHolder CardsHolder { get; private set; }
        public HandEvaluationResult Evaluation { get; private set; }
        public int Rank { get; internal set; }

        public EvaluatedCardHolder(IStringCardsHolder holder, EvaluatorTypeEnum type)
        {
            CardsHolder = holder;
            Evaluation = HandEvaluators.Evaluate(holder.PlayerCards,holder.CommunityCards,type);
            Rank = int.MaxValue;
        }
    }
}
