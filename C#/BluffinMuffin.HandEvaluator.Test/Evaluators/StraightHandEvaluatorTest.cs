using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Evaluators;
using BluffinMuffin.HandEvaluator.Selectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BluffinMuffin.HandEvaluator.Enums.NominalValueEnum;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class StraightHandEvaluatorTest
    {
        private readonly AbstractEvaluatorFactory m_Evaluator = new SingleEvaluatorFactory<StraightHandEvaluator>();

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private HandEvaluationResult Evaluate(params string[] cards)
        {
            return HandEvaluators.Evaluate(cards, null, new EvaluationParams { Selector = new OnlyHoleCardsSelector(), EvaluatorFactory = m_Evaluator });
        }

        [TestMethod]
        public void NoCardsShouldBeNull()
        {
            var res = Evaluate();
            Assert.IsNull(res);
        }

        [TestMethod]
        public void LessThan5CardsShouldBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithNoStraightShouldBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "3c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c");
            Assert.IsNotNull(res);
            Assert.AreEqual(Six, res.Cards.First().First().Value);
            Assert.AreEqual(Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void FiveCardsWithLowestStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "Ac");
            Assert.IsNotNull(res);
            Assert.AreEqual(Five, res.Cards.First().First().Value);
            Assert.AreEqual(Ace, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void FiveCardsWithLowestStraightShouldBeNullIfNoAceForLowStraight()
        {
            var res = HandEvaluators.Evaluate(new[] { "5d", "4c", "3h", "2s", "Ac" }, null, new EvaluationParams { Selector = new OnlyHoleCardsSelector(), EvaluatorFactory = m_Evaluator, UseAceForLowStraight = false });
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithLowestStraightShouldNotBeNullInStrippedDeck()
        {
            var res = HandEvaluators.Evaluate(new[] {"10d", "9c", "8h", "7s", "Ac"}, null, new EvaluationParams {Selector = new OnlyHoleCardsSelector(), EvaluatorFactory = m_Evaluator, UsedCardValues = new[] {Seven, Eight, Nine, Ten, Jack, Queen, King, Ace}});
            Assert.IsNotNull(res);
            Assert.AreEqual(Ten, res.Cards.First().First().Value);
            Assert.AreEqual(Ace, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void SixCardsWithNoStraightShouldBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "3c", "9h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixCardsWithStraightButOneShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "9h");
            Assert.IsNotNull(res);
            Assert.AreEqual(Six, res.Cards.First().First().Value);
            Assert.AreEqual(Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void SixCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c");
            Assert.IsNotNull(res);
            Assert.AreEqual(Seven, res.Cards.First().First().Value);
            Assert.AreEqual(Three, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void SevenCardsWithNoStraightShouldBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "3c", "9h", "10h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenCardsWithStraightButTwoShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "9h", "10h");
            Assert.IsNotNull(res);
            Assert.AreEqual(Six, res.Cards.First().First().Value);
            Assert.AreEqual(Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void SevenCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(Eight, res.Cards.First().First().Value);
            Assert.AreEqual(Four, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void TenCardsWithNoStraightShouldBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "3c", "9h", "10h", "2s", "Kd", "Jd");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenCardsWithStraightButTwoShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "9h", "10h", "2s", "Kd", "Jd");
            Assert.IsNotNull(res);
            Assert.AreEqual(Six, res.Cards.First().First().Value);
            Assert.AreEqual(Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void TenCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c", "8c", "9c", "10c", "Jc");
            Assert.IsNotNull(res);
            Assert.AreEqual(Jack, res.Cards.First().First().Value);
            Assert.AreEqual(Seven, res.Cards.First().Last().Value);
        }
    }
}
