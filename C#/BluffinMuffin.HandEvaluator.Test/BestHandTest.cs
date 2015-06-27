using System;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class BestHandTest
    {

        [TestMethod]
        public void LessThanFiveCardsShouldBeNull()
        {
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5s", "8d", "As" });
            Assert.IsNull(res);
        }


        [TestMethod]
        public void ShouldReturnHighCard()
        {
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "8d", "Ac", "7s", "10h", "2s" });
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
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "8d", "Ac", "7s", "10h", "Kh" });
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
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "8d", "7c", "7s", "10h", "Kh" });
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
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "8d", "Kc", "7s", "10h", "Kh" });
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
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "Ad", "Kc", "Qs", "10h", "Jh" });
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
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5s", "As", "Kc", "Qs", "10s", "Jh" });
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
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "8d", "7c", "5s", "5h", "Kh" });
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.FullHouse);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Five);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Count, 2);
        }

        [TestMethod]
        public void ShouldReturnFourOfAKind()
        {
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "5d", "7c", "5s", "5h", "Kh" });
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Hand, HandEnum.FourOfAKind);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Five);
            Assert.AreEqual(res.Cards.Skip(1).First().First().Value, NominalValueEnum.King);
            Assert.AreEqual(res.Cards.Count, 2);
        }


        [TestMethod]
        public void ShouldReturnStraightFlush()
        {
            var res = HandEvaluator.Evaluate(new[] { "Ks", "5h", "Ah", "Kh", "Qh", "10h", "Jh" });
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
