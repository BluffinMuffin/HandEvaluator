using System.Collections.Generic;
using System.Linq;

namespace BluffinMuffin.HandEvaluator.Selectors
{
    public class UseAllCardsSelector : AbstractCardsSelector
    {
        public override IEnumerable<IEnumerable<PlayingCard>> SelectCards(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluationParams parms)
        {
            yield return playerCards.Union(communityCards).Select(c => new PlayingCard(c, parms));
        }
    }
}
