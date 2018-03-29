using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smads.SweepDimension.Game.Components.Tests.GameOverStrategyTests;
using Smads.SweepDimension.Game.Components.Tests.ScoringStrategyTests;

namespace Smads.SweepDimension.Game.Components.Tests
{
    [TestClass]
    public class GameRuleTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(4)]
        public void ScoringTest(int score)
        {
            var rules = new GameRules(new TestGameOverStrategy(false), new TestGameOverStrategy(false), new TestScoringStrategy(score));

            Assert.AreEqual(score, rules.CalculateScore(null));
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void GameWonTest(bool won)
        {
            var rules = new GameRules(new TestGameOverStrategy(won), new TestGameOverStrategy(false), new TestScoringStrategy(0));

            Assert.AreEqual(won, rules.WinConditionMet(null));
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void GameLostTest(bool lost)
        {
            var rules = new GameRules(new TestGameOverStrategy(false), new TestGameOverStrategy(lost), new TestScoringStrategy(0));

            Assert.AreEqual(lost, rules.LoseConditionMet(null));
        }


    }
}
