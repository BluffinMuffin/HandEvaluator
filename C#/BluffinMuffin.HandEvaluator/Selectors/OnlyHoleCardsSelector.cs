using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.HandEvaluator.Attributes;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.Selectors
{
    [CardSelection(CardSelectionEnum.OnlyHoleCards)]
    class OnlyHoleCardsSelector : AbstractCardsSelector
    {
        public override IEnumerable<IEnumerable<PlayingCard>> SelectCards(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluationParams parms)
        {
            yield return playerCards.Select(c => new PlayingCard(c, parms));
        }
    }
}
