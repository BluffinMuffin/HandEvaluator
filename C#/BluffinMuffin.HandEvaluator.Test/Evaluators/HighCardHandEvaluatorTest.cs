using System.Linq;
using BluffinMuffin.HandEvaluator.Enums;
using BluffinMuffin.HandEvaluator.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluffinMuffin.HandEvaluator.Test.Evaluators
{
    [TestClass]
    public class HighCardHandEvaluatorTest
    {
        private readonly AbstractHandEvaluator m_Evaluator = new HighCardAbstractHandEvaluator();

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
            var res = Evaluate("5c", "5s", "6d");
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FiveCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Eight);
        }

        [TestMethod]
        public void SixCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c", "9h");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Nine);
        }

        [TestMethod]
        public void SevenCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c", "9h", "10c");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.Ten);
        }

        [TestMethod]
        public void TenCardsShouldNotBeNull()
        {
            var res = Evaluate("5c", "5s", "6d", "7h", "8c", "9h", "10s", "Jh", "Qc", "kh");
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Cards.First().First().Value, NominalValueEnum.King);
        }
    }
}
