using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.HandEvaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.HandEvaluators
{
    [TestClass]
    public class TwoPairsHandEvaluatorTest
    {
        private readonly HandEvaluator m_Evaluator = new TwoPairsHandEvaluator();

        private HandEvaluationResult Evaluate(params string[] cards)
        {
            return m_Evaluator.Evaluation(cards.Select(x => new PlayingCard(x)).ToArray());
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
            var res = Evaluate("5c", "5s", "6d", "6c");
            Assert.IsNull(res);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.Five);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.Five);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.Five);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.Five);
        }
    }
}
