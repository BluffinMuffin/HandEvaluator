using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluatedCardHolder
    {
        public IStringCardsHolder CardsHolder { get; private set; }
        public HandEvaluationResult Evaluation { get; private set; }
        public int Rank { get; internal set; }

        public EvaluatedCardHolder(IStringCardsHolder holder)
        {
            CardsHolder = holder;
            Evaluation = HandEvaluator.Evaluate(holder.StringCards);
            Rank = int.MaxValue;
        }
    }
}
