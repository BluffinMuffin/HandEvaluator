using System;
using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Exceptions;
using BluffinMuffin.HandEvaluator.HandEvaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.HandEvaluators
{
    [TestClass]
    public class FlushHandEvaluatorTest
    {
        private HandEvaluator m_Evaluator = new FlushHandEvaluator();

        private HandEvaluationResult Evaluate(params string[] cards)
        {
            return m_Evaluator.Evaluation(cards.Select(x => new PlayingCard(x)).ToArray());
        }

        [TestMethod]
        public void NoCardsShouldBeNull()
        {
            var res = Evaluate();
            Assert.IsNull(res);
        }

        [TestMethod]
        public void LessThan5CardsShouldBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void SixMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c", "9h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixSameSuitCardsButOneShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9h");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void SixSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9c");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void SevenMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c", "9h", "Ah");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenSameSuitCardsButTwoShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9h", "Ah");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void SevenSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9c", "Ac");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TenMixedSuitCardsShouldBeNull()
        {
            var res = Evaluate("5c", "4h", "8c", "2c", "3c", "9h", "Ah", "2s", "Kd", "Jd");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenSameSuitCardsButTwoShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9h", "Ah", "2s", "Kd", "Jd");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TenSameSuitCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "4c", "8c", "2c", "3c", "9c", "Ac", "2c", "Kc", "Jc");
            Assert.IsNotNull(res);
        }
    }
}
