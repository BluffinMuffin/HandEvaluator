using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class ThreeOfAKindHandEvaluatorTest
    {
        private readonly AbstractHandEvaluator m_Evaluator = new ThreeOfAKindAbstractHandEvaluator();

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
            var res = Evaluate("4c", "4h", "4s");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithoutThreeOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "3h", "3c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsWithThreeOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "4h", "3c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }

        [TestMethod]
        public void SixCardsWithoutThreeOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "3h", "3c", "2h");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SixCardsWithThreeOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "4h", "3c", "2h");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }

        [TestMethod]
        public void SevenCardsWithoutThreeOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "3h", "3c", "2h", "2c");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void SevenCardsWithThreeOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "4h", "3c", "2h", "2c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }

        [TestMethod]
        public void TenCardsWithoutThreeOfAKindShouldBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "3h", "3c", "2h", "2c", "ah", "ac", "kh");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void TenCardsWithThreeOfAKindShouldNotBeNull()
        {
            var res = Evaluate("4c", "4s", "5d", "4h", "3c", "2h", "2c", "ah", "ac", "kh");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Four);
        }
    }
}
