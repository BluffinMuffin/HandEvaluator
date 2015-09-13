using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class FlushHandEvaluatorTest
    {
        private readonly AbstractEvaluatorFactory m_Evaluator = new SingleEvaluatorFactory<FlushHandEvaluator>();

        private HandEvaluationResult Evaluate(params string[] cards)
        {
            return HandEvaluators.Evaluate(cards, null, new EvaluationParams { CardSelection = CardSelectionEnum.OnlyHoleCards, EvaluatorFactory = m_Evaluator });
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
            var res = Evaluate("5c", "4c", "8c", "2c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SixMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c", "9h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixSameSuitCardsButOneShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9h");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SixSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Nine, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SevenMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c", "9h", "Ah");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenSameSuitCardsButTwoShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9h", "Ah");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SevenSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9c", "Ac");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void TenMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c", "9h", "Ah", "2s", "Kd", "Jd");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenSameSuitCardsButTwoShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9h", "Ah", "2s", "Kd", "Jd");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void TenSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9c", "Ac", "2c", "Kc", "Jc");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }
    }
}
