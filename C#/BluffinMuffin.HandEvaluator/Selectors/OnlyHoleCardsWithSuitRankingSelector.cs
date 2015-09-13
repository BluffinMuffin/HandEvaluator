using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.HandEvaluator.Attributes;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.Selectors
{
    [CardSelection(CardSelectionEnum.OnlyHoleCardsWithSuitRanking)]
    class OnlyHoleCardsWithSuitRankingSelector : AbstractCardsSelector
    {
        public override IEnumerable<IEnumerable<PlayingCard>> SelectCards(IEnumerable<string> playerCards, IEnumerable<string> communityCards)
        {
            yield return playerCards.Select(c => new SuitRankedPlayingCard(c)).OrderByDescending(x => x);
        }
    }
}
