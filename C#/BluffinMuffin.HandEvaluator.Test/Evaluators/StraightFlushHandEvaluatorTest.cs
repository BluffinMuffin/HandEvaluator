using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class StraightFlushHandEvaluatorTest
    {
        private readonly AbstractHandEvaluator m_Evaluator = new StraightFlushAbstractHandEvaluator();

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
            var res = Evaluate("5c", "4c", "3c", "2c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithNoStraightFlushShouldBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "3c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithStraightFlushShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "6c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void FiveCardsWithStraightNoFlushShouldBeNull()
        {
            var res = Evaluate("5c", "4s", "3h", "2d", "6c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithFlushNoStraightShouldBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "7c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithLowestFlushStraightShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "Ac");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SixCardsWithNoStraightFlushShouldBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "3c", "9h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixCardsWithStraightFlushButOneShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "6c", "9h");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SixCardsWithStraightFlushShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "6c", "7c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Three, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SevenCardsWithNoStraightFlushShouldBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "3c", "9h", "10h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenCardsWithStraightFlushButTwoShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "6c", "9h", "10h");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void SevenCardsWithStraightFlushShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "6c", "7c", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Four, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void TenCardsWithNoStraightFlushShouldBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "3c", "9h", "10h", "2s", "Kd", "Jd");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenCardsWithStraightFlushButTwoShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "6c", "9h", "10h", "2s", "Kd", "Jd");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Six, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }

        [TestMethod]
        public void TenCardsWithStraightFlushShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "3c", "2c", "6c", "7c", "8c", "9c", "10c", "Jc");
            Assert.IsNotNull(res);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().Last().Value);
            Assert.AreEqual(SuitEnum.Clubs, res.Cards.First().First().Suit);
        }
    }
}
