using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Evaluators;
using BluffinMuffin.HandEvaluator.Selectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class StraightHandEvaluatorTest
    {
        private readonly AbstractEvaluatorFactory m_Evaluator = new SingleEvaluatorFactory<StraightHandEvaluator>();

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
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void FiveCardsWithLowestStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "Ac");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().Last().Value);
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
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void SixCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Three, res.Cards.First().Last().Value);
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
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void SevenCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Four, res.Cards.First().Last().Value);
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
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
        }

        [TestMethod]
        public void TenCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c", "8c", "9c", "10c", "Jc");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().Last().Value);
        }
    }
}
