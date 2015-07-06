using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class HandComparaisonTest
    {

        [TestMethod]
        public void TestsBetweenHighCards()
        {
            var biggest = HandEvaluators.Evaluate(new[] { "Ks", "Ac" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "Kh", "5s" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "Kd", "5d" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "Qs", "5c" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "10s", "Ac" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "10c", "5c" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "8h", "5s" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "8c", "5d" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "3s", "5h" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "10s", "8c" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "10c", "3s" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "8h", "3d" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "8s", "3h" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "7h", "2h" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "10d", "Ac" }, new[] { "8d", "10c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "10s", "5c" }, new[] { "8d", "10c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "8h", "9s" }, new[] { "8d", "8c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "8s", "9d" }, new[] { "8d", "8c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "8s", "3h" }, new[] { "8d", "8c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "Ad", "Ks" }, new[] { "Qh", "Jc", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "9d", "Ks" }, new[] { "Qh", "Jc", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "8d", "9s" }, new[] { "Qh", "Jc", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "8h", "9c" }, new[] { "Qh", "Jc", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "3d", "4s" }, new[] { "Ah", "Jc", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "Kc", "Ac" }, new[] { "8c", "3c", "7c", "10c", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "Kc", "Ac" }, new[] { "8d", "3c", "7c", "10c", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "Ks", "Ac" }, new[] { "8s", "3c", "7s", "10s", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "Kd", "Ac" }, new[] { "8d", "3c", "7d", "10d", "2d" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "Ks", "Ac" }, new[] { "8d", "3d", "7d", "10d", "2d" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "10d", "Ac" }, new[] { "8d", "10c", "7s", "10h", "As" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "10s", "5c" }, new[] { "8d", "10c", "7s", "10h", "5s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "8h", "9s" }, new[] { "8d", "8c", "7s", "10h", "9c" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "8s", "9d" }, new[] { "8d", "8c", "7s", "10h", "9c" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "8s", "3h" }, new[] { "8d", "8c", "7s", "10h", "3s" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "10d", "Ac" }, new[] { "8d", "10c", "7s", "10h", "10s" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "10s", "5c" }, new[] { "8d", "10c", "7s", "10h", "10d" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "8h", "9s" }, new[] { "8d", "8c", "7s", "10h", "8s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "8s", "4d" }, new[] { "8d", "8c", "5s", "10h", "8h" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "7h", "3h" }, new[] { "7d", "7c", "7s", "10h", "3s" }, EvaluatorTypeEnum.TexasHoldEm);
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
            var biggest = HandEvaluators.Evaluate(new[] { "Ad", "Kd" }, new[] { "Qd", "Jd", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var big = HandEvaluators.Evaluate(new[] { "9d", "Kd" }, new[] { "Qd", "Jd", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal1 = HandEvaluators.Evaluate(new[] { "8d", "9d" }, new[] { "Qd", "Jd", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var normal2 = HandEvaluators.Evaluate(new[] { "8h", "9h" }, new[] { "Qh", "Jh", "10h", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            var smallest = HandEvaluators.Evaluate(new[] { "3d", "4d" }, new[] { "Ad", "Jc", "10d", "5d", "2d" }, EvaluatorTypeEnum.TexasHoldEm);
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
        [TestMethod]
        public void TestOrdering()
        {
            var straightFlush = HandEvaluators.Evaluate(new[] { "Ad", "Kd" }, new[] { "Qd", "Jd", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.StraightFlush, straightFlush.Hand);

            var fourOfAKind = HandEvaluators.Evaluate(new[] { "10d", "Ac" }, new[] { "8d", "10c", "7s", "10h", "10s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.FourOfAKind, fourOfAKind.Hand);

            var fullHouse = HandEvaluators.Evaluate(new[] { "10d", "Ac" }, new[] { "8d", "10c", "7s", "10h", "As" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.FullHouse, fullHouse.Hand);

            var flush = HandEvaluators.Evaluate(new[] { "Kc", "Ac" }, new[] { "8c", "3c", "7c", "10c", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.Flush, flush.Hand);

            var straight = HandEvaluators.Evaluate(new[] { "Ad", "Ks" }, new[] { "Qh", "Jc", "10d", "5h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.Straight, straight.Hand);

            var threeOfAKind = HandEvaluators.Evaluate(new[] { "10d", "Ac" }, new[] { "8d", "10c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.ThreeOfAKind, threeOfAKind.Hand);

            var twoPairs = HandEvaluators.Evaluate(new[] { "10s", "8c" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.TwoPairs, twoPairs.Hand);

            var onePair = HandEvaluators.Evaluate(new[] { "10s", "Ac" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.OnePair, onePair.Hand);

            var highCard = HandEvaluators.Evaluate(new[] { "Ks", "Ac" }, new[] { "8d", "3c", "7s", "10h", "2s" }, EvaluatorTypeEnum.TexasHoldEm);
            Assert.AreEqual(HandEnum.HighCard, highCard.Hand);

            Assert.AreEqual(1, straightFlush.CompareTo(fourOfAKind));
            Assert.AreEqual(1, straightFlush.CompareTo(fullHouse));
            Assert.AreEqual(1, straightFlush.CompareTo(flush));
            Assert.AreEqual(1, straightFlush.CompareTo(straight));
            Assert.AreEqual(1, straightFlush.CompareTo(threeOfAKind));
            Assert.AreEqual(1, straightFlush.CompareTo(twoPairs));
            Assert.AreEqual(1, straightFlush.CompareTo(onePair));
            Assert.AreEqual(1, straightFlush.CompareTo(highCard));
            Assert.AreEqual(1, fourOfAKind.CompareTo(fullHouse));
            Assert.AreEqual(1, fourOfAKind.CompareTo(flush));
            Assert.AreEqual(1, fourOfAKind.CompareTo(straight));
            Assert.AreEqual(1, fourOfAKind.CompareTo(threeOfAKind));
            Assert.AreEqual(1, fourOfAKind.CompareTo(twoPairs));
            Assert.AreEqual(1, fourOfAKind.CompareTo(onePair));
            Assert.AreEqual(1, fourOfAKind.CompareTo(highCard));
            Assert.AreEqual(1, fullHouse.CompareTo(flush));
            Assert.AreEqual(1, fullHouse.CompareTo(straight));
            Assert.AreEqual(1, fullHouse.CompareTo(threeOfAKind));
            Assert.AreEqual(1, fullHouse.CompareTo(twoPairs));
            Assert.AreEqual(1, fullHouse.CompareTo(onePair));
            Assert.AreEqual(1, fullHouse.CompareTo(highCard));
            Assert.AreEqual(1, flush.CompareTo(straight));
            Assert.AreEqual(1, flush.CompareTo(threeOfAKind));
            Assert.AreEqual(1, flush.CompareTo(twoPairs));
            Assert.AreEqual(1, flush.CompareTo(onePair));
            Assert.AreEqual(1, flush.CompareTo(highCard));
            Assert.AreEqual(1, straight.CompareTo(threeOfAKind));
            Assert.AreEqual(1, straight.CompareTo(twoPairs));
            Assert.AreEqual(1, straight.CompareTo(onePair));
            Assert.AreEqual(1, straight.CompareTo(highCard));
            Assert.AreEqual(1, threeOfAKind.CompareTo(twoPairs));
            Assert.AreEqual(1, threeOfAKind.CompareTo(onePair));
            Assert.AreEqual(1, threeOfAKind.CompareTo(highCard));
            Assert.AreEqual(1, twoPairs.CompareTo(onePair));
            Assert.AreEqual(1, twoPairs.CompareTo(highCard));
            Assert.AreEqual(1, onePair.CompareTo(highCard));
        }
    }
}
