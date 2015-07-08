using System.Collections.Generic;

namespace BluffinMuffin.HandEvaluator
{
    public interface IStringCardsHolder
    {
        IEnumerable<string> PlayerCards { get; }
        IEnumerable<string> CommunityCards { get; }
    }
}
