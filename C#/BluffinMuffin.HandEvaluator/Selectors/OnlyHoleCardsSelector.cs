using System.Collections.Generic;
using System.Linq;

namespace BluffinMuffin.HandEvaluator.Selectors
{
    public class OnlyHoleCardsSelector : AbstractCardsSelector
    {
        public override IEnumerable<IEnumerable<PlayingCard>> SelectCards(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluationParams parms)
        {
            yield return playerCards.Select(c => new PlayingCard(c, parms));
        }
    }
}
