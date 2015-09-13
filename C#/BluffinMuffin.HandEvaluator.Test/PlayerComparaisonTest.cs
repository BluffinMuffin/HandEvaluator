using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    internal class Player : IStringCardsHolder
    {
        public IEnumerable<string> PlayerCards { get; }
        public IEnumerable<string> CommunityCards { get; }

        public Player(params string[] cards)
        {
            PlayerCards = cards.Take(2);
            CommunityCards = cards.Skip(2);
        }
    }

    internal static class ResultExtensions
    {
        public static int RankOf(this IEnumerable<IGrouping<int, EvaluatedCardHolder>> result, Player p)
        {
            return result.SelectMany(x => x).First(x => x.CardsHolder == p).Rank;
        }
    }

    [TestClass]
    public class PlayerComparaisonTest
    {

        [TestMethod]
        public void TestsBetweenHighCards()
        {
            var biggest = new Player("Ks", "Ac", "8d", "3c", "7s", "10h", "2s");
            var normal1 = new Player("Kh", "5s", "8d", "3c", "7s", "10h", "2s");
            var normal2 = new Player("Kd", "5d", "8d", "3c", "7s", "10h", "2s");
            var smallest = new Player("Qs", "5c", "8d", "3c", "7s", "10h", "2s");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(normal1));
            Assert.AreEqual(2, result.RankOf(normal2));
            Assert.AreEqual(3, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenOnePairs()
        {
            var biggest = new Player("10s", "Ac", "8d", "3c", "7s", "10h", "2s");
            var big = new Player("10c", "5c", "8d", "3c", "7s", "10h", "2s");
            var normal1 = new Player("8h", "5s", "8d", "3c", "7s", "10h", "2s");
            var normal2 = new Player("8c", "5d", "8d", "3c", "7s", "10h", "2s");
            var smallest = new Player("3s", "5h", "8d", "3c", "7s", "10h", "2s");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenTwoPairs()
        {
            var biggest = new Player("10s", "8c", "8d", "3c", "7s", "10h", "2s");
            var big = new Player("10c", "3s", "8d", "3c", "7s", "10h", "2s");
            var normal1 = new Player("8h", "3d", "8d", "3c", "7s", "10h", "2s");
            var normal2 = new Player("8s", "3h", "8d", "3c", "7s", "10h", "2s");
            var smallest = new Player("7h", "2h", "8d", "3c", "7s", "10h", "2s");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenThreeOfAKinds()
        {
            var biggest = new Player("10d", "Ac", "8d", "10c", "7s", "10h", "2s");
            var big = new Player("10s", "5c", "8d", "10c", "7s", "10h", "2s");
            var normal1 = new Player("8h", "9s", "8d", "8c", "7s", "10h", "2s");
            var normal2 = new Player("8s", "9d", "8d", "8c", "7s", "10h", "2s");
            var smallest = new Player("8s", "3h", "8d", "8c", "7s", "10h", "2s");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenStraights()
        {
            var biggest = new Player("Ad", "Ks", "Qh", "Jc", "10d", "5h", "2s");
            var big = new Player("9d", "Ks", "Qh", "Jc", "10d", "5h", "2s");
            var normal1 = new Player("8d", "9s", "Qh", "Jc", "10d", "5h", "2s");
            var normal2 = new Player("8h", "9c", "Qh", "Jc", "10d", "5h", "2s");
            var smallest = new Player("3d", "4s", "Ah", "Jc", "10d", "5h", "2s");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenFlushes()
        {
            var biggest = new Player("Kc", "Ac", "8c", "3c", "7c", "10c", "2s");
            var big = new Player("Kc", "Ac", "8d", "3c", "7c", "10c", "2s");
            var normal1 = new Player("Ks", "Ac", "8s", "3c", "7s", "10s", "2s");
            var normal2 = new Player("Kd", "Ac", "8d", "3c", "7d", "10d", "2d");
            var smallest = new Player("Ks", "Ac", "8d", "3d", "7d", "10d", "2d");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenFullHouses()
        {
            var biggest = new Player("10d", "Ac", "8d", "10c", "7s", "10h", "As");
            var big = new Player("10s", "5c", "8d", "10c", "7s", "10h", "5s");
            var normal1 = new Player("8h", "9s", "8d", "8c", "7s", "10h", "9c");
            var normal2 = new Player("8s", "9d", "8d", "8c", "7s", "10h", "9c");
            var smallest = new Player("8s", "3h", "8d", "8c", "7s", "10h", "3s");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenFourOfAKinds()
        {
            var biggest = new Player("10d", "Ac", "8d", "10c", "7s", "10h", "10s");
            var big = new Player("10s", "5c", "8d", "10c", "7s", "10h", "10d");
            var normal1 = new Player("8h", "9s", "8d", "8c", "7s", "10h", "8s");
            var normal2 = new Player("8s", "4d", "8d", "8c", "5s", "10h", "8h");
            var smallest = new Player("7h", "3h", "7d", "7c", "7s", "10h", "3s");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestsBetweenStraightFlushes()
        {
            var biggest = new Player("Ad", "Kd", "Qd", "Jd", "10d", "5h", "2s");
            var big = new Player("9d", "Kd", "Qd", "Jd", "10d", "5h", "2s");
            var normal1 = new Player("8d", "9d", "Qd", "Jd", "10d", "5h", "2s");
            var normal2 = new Player("8h", "9h", "Qh", "Jh", "10h", "5h", "2s");
            var smallest = new Player("3d", "4d", "Ad", "Jc", "10d", "5d", "2d");

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, biggest, big, normal1, normal2, smallest).ToArray();

            Assert.AreEqual(1, result.RankOf(biggest));
            Assert.AreEqual(2, result.RankOf(big));
            Assert.AreEqual(3, result.RankOf(normal1));
            Assert.AreEqual(3, result.RankOf(normal2));
            Assert.AreEqual(4, result.RankOf(smallest));
        }

        [TestMethod]
        public void TestOrdering()
        {
            var straightFlush = new Player("Ad", "Kd", "Qd", "Jd", "10d", "5h", "2s");
            Assert.AreEqual(HandEnum.StraightFlush, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,straightFlush.PlayerCards, straightFlush.CommunityCards).Hand);

            var fourOfAKind = new Player("10d", "Ac", "8d", "10c", "7s", "10h", "10s");
            Assert.AreEqual(HandEnum.FourOfAKind, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,fourOfAKind.PlayerCards, fourOfAKind.CommunityCards).Hand);

            var fullHouse = new Player("10d", "Ac", "8d", "10c", "7s", "10h", "As");
            Assert.AreEqual(HandEnum.FullHouse, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,fullHouse.PlayerCards, fullHouse.CommunityCards).Hand);

            var flush = new Player("Kc", "Ac", "8c", "3c", "7c", "10c", "2s");
            Assert.AreEqual(HandEnum.Flush, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,flush.PlayerCards, flush.CommunityCards).Hand);

            var straight = new Player("Ad", "Ks", "Qh", "Jc", "10d", "5h", "2s");
            Assert.AreEqual(HandEnum.Straight, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,straight.PlayerCards, straight.CommunityCards).Hand);

            var threeOfAKind = new Player("10d", "Ac", "8d", "10c", "7s", "10h", "2s");
            Assert.AreEqual(HandEnum.ThreeOfAKind, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,threeOfAKind.PlayerCards, threeOfAKind.CommunityCards).Hand);

            var twoPairs = new Player("10s", "8c", "8d", "3c", "7s", "10h", "2s");
            Assert.AreEqual(HandEnum.TwoPairs, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,twoPairs.PlayerCards, twoPairs.CommunityCards).Hand);

            var onePair = new Player("10s", "Ac", "8d", "3c", "7s", "10h", "2s");
            Assert.AreEqual(HandEnum.OnePair, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,onePair.PlayerCards, onePair.CommunityCards).Hand);

            var highCard = new Player("Ks", "Ac", "8d", "3c", "7s", "10h", "2s");
            Assert.AreEqual(HandEnum.HighCard, HandEvaluators.Evaluate( CardSelectionEnum.AllPlayerAndAllCommunity,highCard.PlayerCards, highCard.CommunityCards).Hand);

            var result = HandEvaluators.Evaluate(CardSelectionEnum.AllPlayerAndAllCommunity, straightFlush, fourOfAKind, fullHouse, flush, straight, threeOfAKind, twoPairs, onePair, highCard).ToArray();

            Assert.AreEqual(1, result.RankOf(straightFlush));
            Assert.AreEqual(2, result.RankOf(fourOfAKind));
            Assert.AreEqual(3, result.RankOf(fullHouse));
            Assert.AreEqual(4, result.RankOf(flush));
            Assert.AreEqual(5, result.RankOf(straight));
            Assert.AreEqual(6, result.RankOf(threeOfAKind));
            Assert.AreEqual(7, result.RankOf(twoPairs));
            Assert.AreEqual(8, result.RankOf(onePair));
            Assert.AreEqual(9, result.RankOf(highCard));
        }
    }
}
