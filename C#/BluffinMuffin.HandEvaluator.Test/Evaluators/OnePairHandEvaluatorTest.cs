using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Evaluators;
using BluffinMuffin.HandEvaluator.Selectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class OnePairHandEvaluatorTest
    {
        private readonly AbstractEvaluatorFactory m_Evaluator = new SingleEvaluatorFactory<OnePairHandEvaluator>();

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
        public void LessThan5CardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
        }

        [TestMethod]
        public void FiveCardsWithoutAPairShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "7h", "8c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithAPairShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
        }

        [TestMethod]
        public void SixCardsWithoutAPairShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "7h", "8c", "9h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixCardsWithAPairShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c", "9h");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
        }

        [TestMethod]
        public void SevenCardsWithoutAPairShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "7h", "8c", "9h", "10c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenCardsWithAPairShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c", "9h", "10c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
        }

        [TestMethod]
        public void TenCardsWithoutAPairShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "7h", "8c", "9h", "10s", "Jh", "Qc", "kh");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenCardsWithAPairShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c", "9h", "10s", "Jh", "Qc", "kh");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
        }
    }
}
