using System;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test
{
    [TestClass]
    public class PlayingCardTest
    {
        private void ValidateGoodValue(NominalValueEnum value, SuitEnum suit)
        {
            string card = PlayingCard.VALUES[(int)value] + PlayingCard.SUITS[(int)suit];

            var playingCard1 = new PlayingCard(card);
            Assert.AreEqual(card, playingCard1.ToString());
            Assert.AreEqual(value, playingCard1.Value);
            Assert.AreEqual(suit, playingCard1.Suit);

            var playingCard2 = new PlayingCard(value,suit);
            Assert.AreEqual(card, playingCard2.ToString());
            Assert.AreEqual(value, playingCard2.Value);
            Assert.AreEqual(suit, playingCard2.Suit);
        }


        [TestMethod]
        public void ValidateAllGoodValues()
        {
            foreach (NominalValueEnum v in Enum.GetValues(typeof(NominalValueEnum)))
                foreach(SuitEnum s in Enum.GetValues(typeof(SuitEnum)))
                    ValidateGoodValue(v,s);
        }


        [TestMethod]
        public void ValidateBadLengthOf0()
        {
            try
            {
                new PlayingCard(String.Empty);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException) { }
        }


        [TestMethod]
        public void ValidateBadLengthOf1()
        {
            try
            {
                new PlayingCard("X");
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException) { }
        }


        [TestMethod]
        public void ValidateBadLengthOf4()
        {
            try
            {
                new PlayingCard("XXXX");
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException) { }
        }


        [TestMethod]
        public void ValidateBadValueInString()
        {
            try
            {
                new PlayingCard("3X");
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (InvalidStringRepresentationException) { }
        }
    }
}
