using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.HandEvaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.HandEvaluators
{
    [TestClass]
    public class FullHouseHandEvaluatorTest
    {
        private readonly HandEvaluator m_Evaluator = new FullHouseHandEvaluator();

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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.Last().First().Value, NominalValueEnum.Five);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Five);
            Assert.AreEqual(res.Cards.Last().First().Value, NominalValueEnum.Six);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.Last().First().Value, NominalValueEnum.Five);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.Last().First().Value, NominalValueEnum.Five);
        }
    }
}
