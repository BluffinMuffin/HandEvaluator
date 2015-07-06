using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class StraightHandEvaluatorTest
    {
        private readonly AbstractHandEvaluator m_Evaluator = new StraightAbstractHandEvaluator();

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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Two);
        }
        [TestMethod]
        public void FiveCardsWithLowestStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "Ac");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Five);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Ace);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Two);
        }

        [TestMethod]
        public void SixCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Seven);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Three);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Two);
        }

        [TestMethod]
        public void SevenCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Eight);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Four);
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
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Six);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Two);
        }

        [TestMethod]
        public void TenCardsWithStraightShouldNotBeNull()
        {
            var res = Evaluate("5d", "4c", "3h", "2s", "6c", "7c", "8c", "9c", "10c", "Jc");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Jack);
            Assert.AreEqual(res.Cards.First().Last().Value, NominalValueEnum.Seven);
        }
    }
}
