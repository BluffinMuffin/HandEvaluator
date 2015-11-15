using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.HandRankers;
using BluffinMuffin.HandEvaluator.Selectors;
using static BluffinMuffin.HandEvaluator.Enums.NominalValueEnum;

namespace BluffinMuffin.HandEvaluator
{
    public class EvaluationParams
    {
        public bool UseSuitRanking { get; set; }
        public bool UseAceForLowStraight { get; set; } = true;

        public NominalValueEnum[] UsedCardValues { get; set; } = { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

        public AbstractCardsSelector Selector { get; set; } = new UseAllCardsSelector();

        public AbstractEvaluatorFactory EvaluatorFactory { get; set; } = new BasicEvaluatorFactory();

        public AbstractHandRanker HandRanker { get; set; } = new BasicHandRanker();
    }
}
