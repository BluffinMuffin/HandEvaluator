using System;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class PlayingCardTest
    {
        private void ValidateGoodValue(NominalValueEnum value, SuitEnum suit)
        {
            string card = PlayingCard.VALUES[(int) value] + PlayingCard.SUITS[(int) suit];

            var playingCard1 = new PlayingCard(card);
            Assert.AreEqual(card, playingCard1.ToString());
            Assert.AreEqual(value, playingCard1.Value);
            Assert.AreEqual(suit, playingCard1.Suit);

            var playingCard2 = new PlayingCard(value, suit);
            Assert.AreEqual(card, playingCard2.ToString());
            Assert.AreEqual(value, playingCard2.Value);
            Assert.AreEqual(suit, playingCard2.Suit);
        }


        [TestMethod]
        public void ValidateAllGoodValues()
        {
            foreach (NominalValueEnum v in Enum.GetValues(typeof (NominalValueEnum)))
                foreach (SuitEnum s in Enum.GetValues(typeof (SuitEnum)))
                    ValidateGoodValue(v, s);
        }


        [TestMethod]
        public void ValidateBadLengthOf0()
        {
            try
            {
                var c = new PlayingCard(Empty);
                Assert.Fail(c.ToString()); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException)
            {
            }
        }


        [TestMethod]
        public void ValidateBadLengthOf1()
        {
            try
            {
                var c = new PlayingCard("X");
                Assert.Fail(c.ToString()); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException)
            {
            }
        }


        [TestMethod]
        public void ValidateBadLengthOf4()
        {
            try
            {
                var c = new PlayingCard("XXXX");
                Assert.Fail(c.ToString()); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException)
            {
            }
        }


        [TestMethod]
        public void ValidateBadValueInString()
        {
            try
            {
                var c = new PlayingCard("3X");
                Assert.Fail(c.ToString()); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException)
            {
            }
        }
    }
}
