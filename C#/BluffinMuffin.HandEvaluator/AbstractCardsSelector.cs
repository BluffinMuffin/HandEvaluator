using System.Collections.Generic;

namespace BluffinMuffin.HandEvaluator
{
    public abstract class AbstractCardsSelector
    {
        public abstract IEnumerable<IEnumerable<PlayingCard>> SelectCards(IEnumerable<string> playerCards, IEnumerable<string> communityCards);
    }
}
