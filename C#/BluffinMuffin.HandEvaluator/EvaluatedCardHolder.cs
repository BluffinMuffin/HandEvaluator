using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BluffinMuffin.HandEvaluator
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class EvaluatedCardHolder<T> where T : class, IStringCardsHolder
    {
        public T CardsHolder { get;}
        public HandEvaluationResult Evaluation { get;}
        public int Rank { get; set; }
        public EvaluationParams Parms { get; }

        public EvaluatedCardHolder(T holder, EvaluationParams parms)
        {
            Parms = parms;
            CardsHolder = holder;
            Evaluation = HandEvaluators.Evaluate( holder.PlayerCards, holder.CommunityCards, Parms);
            Rank = int.MaxValue;
        }
    }

    public static class EvaluatedCardHoldersExtensions
    {
        public static int RankOf<T>(this IEnumerable<IGrouping<int, EvaluatedCardHolder<T>>> result, T ch) where T : class, IStringCardsHolder 
        {
            return result.SelectMany(x => x).First(x => x.CardsHolder == ch).Rank;
        }
    }
}
