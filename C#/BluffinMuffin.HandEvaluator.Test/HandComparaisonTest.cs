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
            var biggest = HandEvaluator.Evaluate("Ks", "Ac", "8d", "3c", "7s", "10h", "2s");
            var normal1 = HandEvaluator.Evaluate("Kh", "5s", "8d", "3c", "7s", "10h", "2s");
            var normal2 = HandEvaluator.Evaluate("Kd", "5d", "8d", "3c", "7s", "10h", "2s");
            var smallest = HandEvaluator.Evaluate("Qs", "5c", "8d", "3c", "7s", "10h", "2s");
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
            var biggest = HandEvaluator.Evaluate("10s", "Ac", "8d", "3c", "7s", "10h", "2s");
            var big = HandEvaluator.Evaluate("10c", "5c", "8d", "3c", "7s", "10h", "2s");
            var normal1 = HandEvaluator.Evaluate("8h", "5s", "8d", "3c", "7s", "10h", "2s");
            var normal2 = HandEvaluator.Evaluate("8c", "5d", "8d", "3c", "7s", "10h", "2s");
            var smallest = HandEvaluator.Evaluate("3s", "5h", "8d", "3c", "7s", "10h", "2s");
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
            var biggest = HandEvaluator.Evaluate("10s", "8c", "8d", "3c", "7s", "10h", "2s");
            var big = HandEvaluator.Evaluate("10c", "3s", "8d", "3c", "7s", "10h", "2s");
            var normal1 = HandEvaluator.Evaluate("8h", "3d", "8d", "3c", "7s", "10h", "2s");
            var normal2 = HandEvaluator.Evaluate("8d", "3h", "8d", "3c", "7s", "10h", "2s");
            var smallest = HandEvaluator.Evaluate("7h", "2h", "8d", "3c", "7s", "10h", "2s");
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
            var biggest = HandEvaluator.Evaluate("10d", "Ac", "8d", "10c", "7s", "10h", "2s");
            var big = HandEvaluator.Evaluate("10s", "5c", "8d", "10c", "7s", "10h", "2s");
            var normal1 = HandEvaluator.Evaluate("8h", "9s", "8d", "8c", "7s", "10h", "2s");
            var normal2 = HandEvaluator.Evaluate("8s", "9d", "8d", "8c", "7s", "10h", "2s");
            var smallest = HandEvaluator.Evaluate("8s", "3h", "8d", "8c", "7s", "10h", "2s");
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
            var biggest = HandEvaluator.Evaluate("Ad", "Ks", "Qh", "Jc", "10d", "5h", "2s");
            var big = HandEvaluator.Evaluate("9d", "Ks", "Qh", "Jc", "10d", "5h", "2s");
            var normal1 = HandEvaluator.Evaluate("8d", "9s", "Qh", "Jc", "10d", "5h", "2s");
            var normal2 = HandEvaluator.Evaluate("8h", "9c", "Qh", "Jc", "10d", "5h", "2s");
            var smallest = HandEvaluator.Evaluate("3d", "4s", "Ah", "Jc", "10d", "5h", "2s");
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
            var biggest = HandEvaluator.Evaluate("Kc", "Ac", "8c", "3c", "7c", "10c", "2s");
            var big = HandEvaluator.Evaluate("Kc", "Ac", "8d", "3c", "7c", "10c", "2s");
            var normal1 = HandEvaluator.Evaluate("Ks", "Ac", "8s", "3c", "7s", "10s", "2s");
            var normal2 = HandEvaluator.Evaluate("Kd", "Ac", "8d", "3c", "7d", "10d", "2d");
            var smallest = HandEvaluator.Evaluate("Ks", "Ac", "8d", "3d", "7d", "10d", "2d");
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
            var biggest = HandEvaluator.Evaluate("10d", "Ac", "8d", "10c", "7s", "10h", "As");
            var big = HandEvaluator.Evaluate("10s", "5c", "8d", "10c", "7s", "10h", "5s");
            var normal1 = HandEvaluator.Evaluate("8h", "9s", "8d", "8c", "7s", "10h", "9c");
            var normal2 = HandEvaluator.Evaluate("8s", "9d", "8d", "8c", "7s", "10h", "9c");
            var smallest = HandEvaluator.Evaluate("8s", "3h", "8d", "8c", "7s", "10h", "3s");
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
            var biggest = HandEvaluator.Evaluate("10d", "Ac", "8d", "10c", "7s", "10h", "10s");
            var big = HandEvaluator.Evaluate("10s", "5c", "8d", "10c", "7s", "10h", "10d");
            var normal1 = HandEvaluator.Evaluate("8h", "9s", "8d", "8c", "7s", "10h", "8s");
            var normal2 = HandEvaluator.Evaluate("8s", "4d", "8d", "8c", "5s", "10h", "8h");
            var smallest = HandEvaluator.Evaluate("7h", "3h", "7d", "7c", "7s", "10h", "3s");
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
            var biggest = HandEvaluator.Evaluate("Ad", "Kd", "Qd", "Jd", "10d", "5h", "2s");
            var big = HandEvaluator.Evaluate("9d", "Kd", "Qd", "Jd", "10d", "5h", "2s");
            var normal1 = HandEvaluator.Evaluate("8d", "9d", "Qd", "Jd", "10d", "5h", "2s");
            var normal2 = HandEvaluator.Evaluate("8h", "9h", "Qh", "Jh", "10h", "5h", "2s");
            var smallest = HandEvaluator.Evaluate("3d", "4d", "Ad", "Jc", "10d", "5d", "2d");
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
            var straightFlush = HandEvaluator.Evaluate("Ad", "Kd", "Qd", "Jd", "10d", "5h", "2s");
            Assert.AreEqual(HandEnum.StraightFlush, straightFlush.Hand);

            var fourOfAKind = HandEvaluator.Evaluate("10d", "Ac", "8d", "10c", "7s", "10h", "10s");
            Assert.AreEqual(HandEnum.FourOfAKind, fourOfAKind.Hand);

            var fullHouse = HandEvaluator.Evaluate("10d", "Ac", "8d", "10c", "7s", "10h", "As");
            Assert.AreEqual(HandEnum.FullHouse, fullHouse.Hand);

            var flush = HandEvaluator.Evaluate("Kc", "Ac", "8c", "3c", "7c", "10c", "2s");
            Assert.AreEqual(HandEnum.Flush, flush.Hand);

            var straight = HandEvaluator.Evaluate("Ad", "Ks", "Qh", "Jc", "10d", "5h", "2s");
            Assert.AreEqual(HandEnum.Straight, straight.Hand);

            var threeOfAKind = HandEvaluator.Evaluate("10d", "Ac", "8d", "10c", "7s", "10h", "2s");
            Assert.AreEqual(HandEnum.ThreeOfAKind, threeOfAKind.Hand);

            var twoPairs = HandEvaluator.Evaluate("10s", "8c", "8d", "3c", "7s", "10h", "2s");
            Assert.AreEqual(HandEnum.TwoPairs, twoPairs.Hand);

            var onePair = HandEvaluator.Evaluate("10s", "Ac", "8d", "3c", "7s", "10h", "2s");
            Assert.AreEqual(HandEnum.OnePair, onePair.Hand);

            var highCard = HandEvaluator.Evaluate("Ks", "Ac", "8d", "3c", "7s", "10h", "2s");
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
