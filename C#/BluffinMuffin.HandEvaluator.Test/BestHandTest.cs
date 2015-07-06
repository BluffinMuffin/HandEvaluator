using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class BestHandTest
    {

        [TestMethod]
        public void LessThanFiveCardsShouldBeNull()
        {
            var res = HandEvaluators.Evaluate(new[]{"Ks", "5s"}, new[]{"8d", "As"},EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNull(res);
        }


        [TestMethod]
        public void ShouldReturnHighCard()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "8d", "Ac", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.HighCard);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Ace);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Skip(2).First().First().Value, NominalValueEnum.Ten);
            Assert.AreEqual(res.Cards.Skip(3).First().First().Value, NominalValueEnum.Eight);
            Assert.AreEqual(res.Cards.Skip(4).First().First().Value, NominalValueEnum.Seven);
            Assert.AreEqual(res.Cards.Count,5);
        }


        [TestMethod]
        public void ShouldReturnOnePair()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "8d", "Ac", "7s", "10h", "Kh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.OnePair);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.Ace);
            Assert.AreEqual(res.Cards.Skip(2).First().First().Value, NominalValueEnum.Ten);
            Assert.AreEqual(res.Cards.Skip(3).First().First().Value, NominalValueEnum.Eight);
            Assert.AreEqual(res.Cards.Count, 4);
        }


        [TestMethod]
        public void ShouldReturnTwoPairs()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "8d", "7c", "7s", "10h", "Kh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.TwoPairs);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.Seven);
            Assert.AreEqual(res.Cards.Skip(2).First().First().Value, NominalValueEnum.Ten);
            Assert.AreEqual(res.Cards.Count, 3);
        }


        [TestMethod]
        public void ShouldReturnThreeOfAKind()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "8d", "Kc", "7s", "10h", "Kh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.ThreeOfAKind);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.Ten);
            Assert.AreEqual(res.Cards.Skip(2).First().First().Value, NominalValueEnum.Eight);
            Assert.AreEqual(res.Cards.Count, 3);
        }


        [TestMethod]
        public void ShouldReturnStraight()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "Ad", "Kc", "Qs", "10h", "Jh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.Straight);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Ace);
            Assert.AreEqual(res.Cards.First().Skip(1).First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.First().Skip(2).First().Value, NominalValueEnum.Queen);
            Assert.AreEqual(res.Cards.First().Skip(3).First().Value, NominalValueEnum.Jack);
            Assert.AreEqual(res.Cards.First().Skip(4).First().Value, NominalValueEnum.Ten);
            Assert.AreEqual(res.Cards.Count, 1);
        }


        [TestMethod]
        public void ShouldReturnFlush()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5s" }, new[] { "As", "Kc", "Qs", "10s", "Jh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.Flush);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Ace);
            Assert.AreEqual(res.Cards.First().First().Suit, SuitEnum.Spades);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Skip(2).First().First().Value, NominalValueEnum.Queen);
            Assert.AreEqual(res.Cards.Skip(3).First().First().Value, NominalValueEnum.Ten);
            Assert.AreEqual(res.Cards.Skip(4).First().First().Value, NominalValueEnum.Five);
            Assert.AreEqual(res.Cards.Count, 5);
        }


        [TestMethod]
        public void ShouldReturnFullHouse()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5c" }, new[] { "8d", "7c", "5s", "5h", "Kh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.FullHouse);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Five);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Count, 2);
        }

        [TestMethod]
        public void ShouldReturnFourOfAKind()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5c" }, new[] { "5d", "7c", "5s", "5h", "Kh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.FourOfAKind);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Five);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Count, 2);
        }


        [TestMethod]
        public void ShouldReturnStraightFlush()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "Ah", "Kh", "Qh", "10h", "Jh" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.StraightFlush);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Ace);
            Assert.AreEqual(res.Cards.First().First().Suit, SuitEnum.Hearts);
            Assert.AreEqual(res.Cards.First().Skip(1).First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.First().Skip(2).First().Value, NominalValueEnum.Queen);
            Assert.AreEqual(res.Cards.First().Skip(3).First().Value, NominalValueEnum.Jack);
            Assert.AreEqual(res.Cards.First().Skip(4).First().Value, NominalValueEnum.Ten);
            Assert.AreEqual(res.Cards.Count, 1);
        }

    }
}
