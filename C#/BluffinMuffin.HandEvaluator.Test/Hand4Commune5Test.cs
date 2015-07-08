using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class Hand4Commune5Test
    {
        [TestMethod]
        public void TexasShouldReturnHighCard_AKQ108()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h", "10h", "Qc" }, new[] { "8d", "Ac", "7s", "6s", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.HighCard, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ten, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(4).First().First().Value);
            Assert.AreEqual(5, res.Cards.Count);
        }
        [TestMethod]
        public void OmahaShouldReturnHighCard_AKQ87()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h", "10h", "Qc" }, new[] { "8d", "Ac", "7s", "6s", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.HighCard, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.Skip(4).First().First().Value);
            Assert.AreEqual(5, res.Cards.Count);
        }


        [TestMethod]
        public void TexasShouldReturnTwoPairs_KQA()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "Kh", "Qh", "Qc" }, new[] { "8d", "Ac", "7s", "6s", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.TwoPairs, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }


        [TestMethod]
        public void OmahaShouldReturnOnePair_KA87()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "Kh", "Qh", "Qc" }, new[] { "8d", "Ac", "7s", "6s", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.OnePair, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }


        [TestMethod]
        public void TexasShouldReturnTwoPairs_87K()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h", "10h", "Qc" }, new[] { "8d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.TwoPairs, res.Hand);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }
        [TestMethod]
        public void OmahaShouldReturnOnePair_8KQ7()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "5h", "10h", "Qc" }, new[] { "8d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.OnePair, res.Hand);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }


        [TestMethod]
        public void TexasShouldReturnTwoPairs_87Q()
        {
            var res = HandEvaluators.Evaluate(new[] { "Js", "5h", "2h", "Qc" }, new[] { "8d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.TwoPairs, res.Hand);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnTwoPairs_82Q()
        {
            var res = HandEvaluators.Evaluate(new[] { "Js", "5h", "2h", "Qc" }, new[] { "8d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.TwoPairs, res.Hand);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }

        [TestMethod]
        public void TexasShouldReturnTwoPairs_KQ8()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "Kh", "Qh", "Qc" }, new[] { "8d", "2c", "7s", "6s", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.TwoPairs, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnTwoPairs_K28()
        {
            var res = HandEvaluators.Evaluate(new[] { "Ks", "Kh", "Qh", "Qc" }, new[] { "8d", "2c", "7s", "6s", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.TwoPairs, res.Hand);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Two, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }


        [TestMethod]
        public void TexasShouldReturnFullHouse_78()
        {
            var res = HandEvaluators.Evaluate(new[] { "Js", "5h", "7h", "Qc" }, new[] { "8d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.FullHouse, res.Hand);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(2, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnThreeOfAKind_7J8()
        {
            var res = HandEvaluators.Evaluate(new[] { "Js", "5h", "7h", "Qc" }, new[] { "8d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.ThreeOfAKind, res.Hand);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }

        [TestMethod]
        public void TexasShouldReturnThreeOfAKind_7QJ()
        {
            var res = HandEvaluators.Evaluate(new[] { "Js", "5h", "3h", "Qc" }, new[] { "7d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.ThreeOfAKind, res.Hand);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnThreeOfAKind_7QJ()
        {
            var res = HandEvaluators.Evaluate(new[] { "Js", "5h", "3h", "Qc" }, new[] { "7d", "8c", "7s", "7c", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.ThreeOfAKind, res.Hand);
            Assert.AreEqual(NominalValueEnum.Seven, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }

        [TestMethod]
        public void TexasShouldReturnThreeOfAKind_5QJ()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "5h", "3h", "5c" }, new[] { "7d", "8c", "Js", "Qc", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.ThreeOfAKind, res.Hand);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(3, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnOnePair_6QJ8()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "5h", "3h", "5c" }, new[] { "7d", "8c", "Js", "Qc", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.OnePair, res.Hand);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(4, res.Cards.Count);
        }

        [TestMethod]
        public void TexasShouldReturnStraight_5432A()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "4h", "3h", "Ac" }, new[] { "7d", "8c", "Js", "Qc", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.Straight, res.Hand);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.First().First().Value);
            Assert.AreEqual(1, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnHighCard_AQJ85()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "4h", "3h", "Ac" }, new[] { "7d", "8c", "Js", "Qc", "2s" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.HighCard, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Eight, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(4).First().First().Value);
            Assert.AreEqual(5, res.Cards.Count);
        }

        [TestMethod]
        public void TexasShouldReturnStraight_AKQJ10()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "4h", "3h", "Ac" }, new[] { "7d", "10c", "Js", "Qc", "Ks" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.Straight, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(1, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnHighCard_AKQJ5()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "4h", "3h", "Ac" }, new[] { "7d", "10c", "Js", "Qc", "Ks" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.HighCard, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(NominalValueEnum.King, res.Cards.Skip(1).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Queen, res.Cards.Skip(2).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Jack, res.Cards.Skip(3).First().First().Value);
            Assert.AreEqual(NominalValueEnum.Five, res.Cards.Skip(4).First().First().Value);
            Assert.AreEqual(5, res.Cards.Count);
        }

        [TestMethod]
        public void TexasShouldReturnStraightFlush_AKQJ10()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "4h", "Qh", "As" }, new[] { "7d", "10s", "Js", "Qs", "Ks" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.StraightFlush, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(1, res.Cards.Count);
        }

        [TestMethod]
        public void OmahaShouldReturnStraight_AKQJ10()
        {
            var res = HandEvaluators.Evaluate(new[] { "5s", "4h", "Qh", "Ac" }, new[] { "7d", "10c", "Js", "Qc", "Ks" }, EvaluatorTypeEnum.OmahaHoldEm);
            Assert.IsNotNull(res);
            Assert.AreEqual(HandEnum.Straight, res.Hand);
            Assert.AreEqual(NominalValueEnum.Ace, res.Cards.First().First().Value);
            Assert.AreEqual(1, res.Cards.Count);
        }
    }
}
