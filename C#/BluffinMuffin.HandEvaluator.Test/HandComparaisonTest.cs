using System;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class HandComparaisonTest
    {

        [TestMethod]
        public void TestsBetweenHighCards()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "Ks", "Ac", "8d", "3c", "7s", "10h", "2s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "Kh", "5s", "8d", "3c", "7s", "10h", "2s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "Kd", "5d", "8d", "3c", "7s", "10h", "2s" });
            var smallest = HandEvaluator.Evaluate(new[] { "Qs", "5c", "8d", "3c", "7s", "10h", "2s" });
            Assert.IsTrue(new[] { biggest, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.HighCard));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenOnePairs()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "10s", "Ac", "8d", "3c", "7s", "10h", "2s" });
            var big = HandEvaluator.Evaluate(new[] { "10c", "5c", "8d", "3c", "7s", "10h", "2s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "8h", "5s", "8d", "3c", "7s", "10h", "2s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "8c", "5d", "8d", "3c", "7s", "10h", "2s" });
            var smallest = HandEvaluator.Evaluate(new[] { "3s", "5h", "8d", "3c", "7s", "10h", "2s" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.OnePair));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenTwoPairs()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "10s", "8c", "8d", "3c", "7s", "10h", "2s" });
            var big = HandEvaluator.Evaluate(new[] { "10c", "3s", "8d", "3c", "7s", "10h", "2s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "8h", "3d", "8d", "3c", "7s", "10h", "2s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "8d", "3h", "8d", "3c", "7s", "10h", "2s" });
            var smallest = HandEvaluator.Evaluate(new[] { "7h", "2h", "8d", "3c", "7s", "10h", "2s" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.TwoPairs));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenThreeOfAKinds()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "10d", "Ac", "8d", "10c", "7s", "10h", "2s" });
            var big = HandEvaluator.Evaluate(new[] { "10s", "5c", "8d", "10c", "7s", "10h", "2s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "8h", "9s", "8d", "8c", "7s", "10h", "2s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "8s", "9d", "8d", "8c", "7s", "10h", "2s" });
            var smallest = HandEvaluator.Evaluate(new[] { "8s", "3h", "8d", "8c", "7s", "10h", "2s" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.ThreeOfAKind));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenStraights()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "Ad", "Ks", "Qh", "Jc", "10d", "5h", "2s" });
            var big = HandEvaluator.Evaluate(new[] { "9d", "Ks", "Qh", "Jc", "10d", "5h", "2s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "8d", "9s", "Qh", "Jc", "10d", "5h", "2s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "8h", "9c", "Qh", "Jc", "10d", "5h", "2s" });
            var smallest = HandEvaluator.Evaluate(new[] { "3d", "4s", "Ah", "Jc", "10d", "5h", "2s" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.Straight));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenFlushes()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "Kc", "Ac", "8c", "3c", "7c", "10c", "2s" });
            var big = HandEvaluator.Evaluate(new[] { "Kc", "Ac", "8d", "3c", "7c", "10c", "2s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "Ks", "Ac", "8s", "3c", "7s", "10s", "2s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "Kd", "Ac", "8d", "3c", "7d", "10d", "2d" });
            var smallest = HandEvaluator.Evaluate(new[] { "Ks", "Ac", "8d", "3d", "7d", "10d", "2d" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.Flush));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenFullHouses()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "10d", "Ac", "8d", "10c", "7s", "10h", "As" });
            var big = HandEvaluator.Evaluate(new[] { "10s", "5c", "8d", "10c", "7s", "10h", "5s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "8h", "9s", "8d", "8c", "7s", "10h", "9c" });
            var normal2 = HandEvaluator.Evaluate(new[] { "8s", "9d", "8d", "8c", "7s", "10h", "9c" });
            var smallest = HandEvaluator.Evaluate(new[] { "8s", "3h", "8d", "8c", "7s", "10h", "3s" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.FullHouse));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenFourOfAKinds()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "10d", "Ac", "8d", "10c", "7s", "10h", "10s" });
            var big = HandEvaluator.Evaluate(new[] { "10s", "5c", "8d", "10c", "7s", "10h", "10d" });
            var normal1 = HandEvaluator.Evaluate(new[] { "8h", "9s", "8d", "8c", "7s", "10h", "8s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "8s", "4d", "8d", "8c", "5s", "10h", "8h" });
            var smallest = HandEvaluator.Evaluate(new[] { "7h", "3h", "7d", "7c", "7s", "10h", "3s" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.FourOfAKind));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }

        [TestMethod]
        public void TestsBetweenStraightFlushes()
        {
            var biggest = HandEvaluator.Evaluate(new[] { "Ad", "Kd", "Qd", "Jd", "10d", "5h", "2s" });
            var big = HandEvaluator.Evaluate(new[] { "9d", "Kd", "Qd", "Jd", "10d", "5h", "2s" });
            var normal1 = HandEvaluator.Evaluate(new[] { "8d", "9d", "Qd", "Jd", "10d", "5h", "2s" });
            var normal2 = HandEvaluator.Evaluate(new[] { "8h", "9h", "Qh", "Jh", "10h", "5h", "2s" });
            var smallest = HandEvaluator.Evaluate(new[] { "3d", "4d", "Ad", "Jc", "10d", "5d", "2d" });
            Assert.IsTrue(new[] { biggest, big, normal1, normal2, smallest }.All(x => x.Hand == HandEnum.StraightFlush));
            Assert.AreEqual(1, biggest.CompareTo(big));
            Assert.AreEqual(1, biggest.CompareTo(normal1));
            Assert.AreEqual(1, biggest.CompareTo(normal2));
            Assert.AreEqual(1, biggest.CompareTo(smallest));
            Assert.AreEqual(1, big.CompareTo(normal1));
            Assert.AreEqual(1, big.CompareTo(normal2));
            Assert.AreEqual(1, big.CompareTo(smallest));
            Assert.AreEqual(0, normal1.CompareTo(normal2));
            Assert.AreEqual(1, normal1.CompareTo(smallest));
            Assert.AreEqual(1, normal2.CompareTo(smallest));
        }
    }
}
