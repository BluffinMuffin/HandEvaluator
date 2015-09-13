using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using BluffinMuffin.HandEvaluator.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class TwoPairsHandEvaluatorTest
    {
        private readonly AbstractEvaluatorFactory m_Evaluator = new SingleEvaluatorFactory<TwoPairsAbstractHandEvaluator>();

        private HandEvaluationResult Evaluate(params string[] cards)
        {
            return HandEvaluators.Evaluate(cards, null,new EvaluationParams{CardSelection = CardSelectionEnum.OnlyHoleCards, EvaluatorFactory = m_Evaluator});
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
            var res = Evaluate("5c", "5s", "6d", "6c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(1).First().First().Value);
        }

        [TestMethod]
        public void FiveCardsWithoutTwoPairsShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "6h", "8c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithTwoPairsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "6h", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(1).First().First().Value);
        }

        [TestMethod]
        public void SixCardsWithoutTwoPairsShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "6h", "8c", "9h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixCardsWithTwoPairsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "6h", "8c", "9h");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(1).First().First().Value);
        }

        [TestMethod]
        public void SevenCardsWithoutTwoPairsShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "6h", "8c", "9h", "10c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenCardsWithTwoPairsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "6h", "8c", "9h", "10c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(1).First().First().Value);
        }

        [TestMethod]
        public void TenCardsWithoutTwoPairsShouldBeNull()
        {
            var res = Evaluate("4c", "5s", "6d", "6h", "8c", "9h", "10s", "Jh", "Qc", "kh");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenCardsWithTwoPairsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "6h", "8c", "9h", "10s", "Jh", "Qc", "kh");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(1).First().First().Value);
        }
    }
}
