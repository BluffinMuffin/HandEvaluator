using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.HandEvaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.HandEvaluators
{
    [TestClass]
    public class FourOfAKindHandEvaluatorTest
    {
        private readonly HandEvaluator m_Evaluator = new FourOfAKindHandEvaluator();

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
            var res = Evaluate("4c", "4h", "4s", "4d");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithoutFourOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "3h", "3c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithFourOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "4h", "3c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }

        [TestMethod]
        public void SixCardsWithoutFourOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "3h", "3c", "2h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixCardsWithFourOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "4h", "3c", "2h");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }

        [TestMethod]
        public void SevenCardsWithoutFourOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "3h", "3c", "2h", "2c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenCardsWithFourOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "4h", "3c", "2h", "2c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }

        [TestMethod]
        public void TenCardsWithoutFourOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "3h", "3c", "2h", "2c", "ah", "ac", "kh");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenCardsWithFourOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "4d", "4h", "3c", "2h", "2c", "ah", "ac", "kh");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }
    }
}
