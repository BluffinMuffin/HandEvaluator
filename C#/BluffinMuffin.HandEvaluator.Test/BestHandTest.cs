﻿using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.EvaluatorFactories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class BestHandTest
    {

        [TestMethod]
        public void LessThanFiveCardsShouldBeWorking()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5s"}, new[] {"8d", "As"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.HighCard, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnHighCard()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5h"}, new[] {"8d", "Ac", "7s", "10h", "2s"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.HighCard, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.Skip(4).First().First().Value);
            Assert.AreEqual(5, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnOnePair()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5h"}, new[] {"8d", "Ac", "7s", "10h", "Kh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.OnePair, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnTwoPairs()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5h"}, new[] {"8d", "7c", "7s", "10h", "Kh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.TwoPairs, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnThreeOfAKind()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5h"}, new[] {"8d", "Kc", "7s", "10h", "Kh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.ThreeOfAKind, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnStraight()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5h"}, new[] {"Ad", "Kc", "Qs", "10h", "Jh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.Straight, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().Skip(1).First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.First().Skip(2).First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.First().Skip(3).First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.First().Skip(4).First().Value);
            Assert.AreEqual(1, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnOnePairIfNoStraight()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "Ad", "Kc", "Qs", "10h", "Jh" }, new EvaluationParams{EvaluatorFactory = new NoStraightNoFlushEvaluatorFactory()});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.OnePair, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnFlush()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5s"}, new[] {"As", "Kc", "Qs", "10s", "Jh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.Flush, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Spades, res.Cards.First().First().Suit);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(4).First().First().Value);
            Assert.AreEqual(5, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnOnePairIfNoStraightNoFlush()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5s" }, new[] { "As", "Kc", "Qs", "10s", "Jh" }, new EvaluationParams { EvaluatorFactory = new NoStraightNoFlushEvaluatorFactory() });
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.OnePair, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnFullHouse()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5c"}, new[] {"8d", "7c", "5s", "5h", "Kh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.FullHouse, res.Hand);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(2, res.Cards.Count);
        }

        [TestMethod]
        public void ShouldReturnFourOfAKind()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5c"}, new[] {"5d", "7c", "5s", "5h", "Kh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.FourOfAKind, res.Hand);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(2, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnStraightFlush()
        {
            var res = HandEvaluators.Evaluate(new[] {"Ks", "5h"}, new[] {"Ah", "Kh", "Qh", "10h", "Jh"});
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.StraightFlush, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(SuitEnum.Hearts, res.Cards.First().First().Suit);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().Skip(1).First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.First().Skip(2).First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.First().Skip(3).First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.First().Skip(4).First().Value);
            Assert.AreEqual(1, res.Cards.Count);
        }


        [TestMethod]
        public void ShouldReturnOnePairIfNoStraightFlush()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h" }, new[] { "Ah", "Kh", "Qh", "10h", "Jh" }, new EvaluationParams { EvaluatorFactory = new NoStraightNoFlushEvaluatorFactory() });
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.OnePair, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }

    }
}
