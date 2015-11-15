using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Evaluators;
using BluffinMuffin.HandEvaluator.Selectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class FullHouseHandEvaluatorTest
    {
        private readonly AbstractEvaluatorFactory m_Evaluator = new SingleEvaluatorFactory<FullHouseHandEvaluator>();

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
            var res = Evaluate("5c", "5d", "6d", "6s");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithNoFullHouseShouldBeNull()
        {
            var res = Evaluate("5c", "5d", "6d", "6s", "3c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithFullHouseShouldNotBeNull()
        {
            var res = Evaluate("5c", "5d", "6d", "6s", "6c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Last().First().Value);
        }

        [TestMethod]
        public void SixCardsWithNoFullHouseShouldBeNull()
        {
            var res = Evaluate("5c", "5d", "6d", "6s", "3c", "9h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixCardsWithFullHouseShouldNotBeNull()
        {
            var res = Evaluate("6c", "6d", "5d", "5s", "5c", "7c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.Last().First().Value);
        }

        [TestMethod]
        public void SevenCardsWithNoFullHouseShouldBeNull()
        {
            var res = Evaluate("5c", "5d", "6d", "6s", "3c", "9h", "10h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenCardsWithFullHouseShouldNotBeNull()
        {
            var res = Evaluate("5c", "5d", "6d", "6s", "6c", "7c", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Last().First().Value);
        }

        [TestMethod]
        public void TenCardsWithNoFullHouseShouldBeNull()
        {
            var res = Evaluate("5c", "5d", "6d", "6s", "3c", "9h", "10h", "2s", "Kd", "Jd");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenCardsWithFullHouseShouldNotBeNull()
        {
            var res = Evaluate("5c", "5d", "6d", "6s", "6c", "7c", "8c", "9c", "10c", "Jc");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Last().First().Value);
        }
    }
}
