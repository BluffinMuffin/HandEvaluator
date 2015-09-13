using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.HandEvaluator.Attributes;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator.Selectors
{
    [CardSelection(CardSelectionEnum.TwoPlayersAndThreeCommunity)]
    public class Use2Player3CommunitySelector : AbstractCardsSelector
    {
        public override IEnumerable<IEnumerable<PlayingCard>> SelectCards(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluationParams parms)
        {
            var pc = playerCards.ToArray();
            var cc = communityCards.ToArray();
            for (int i = 0; i < pc.Length; ++i)
                for (int j = i + 1; j < pc.Length; ++j)
                    for (int a = 0; a < cc.Length; ++a)
                        for (int b = a + 1; b < cc.Length; ++b)
                            for (int c = b + 1; c < cc.Length; ++c)
                                yield return new[] {pc[i], pc[j], cc[a], cc[b], cc[c]}.Select(x => new PlayingCard(x, parms));
        }
    }
}
