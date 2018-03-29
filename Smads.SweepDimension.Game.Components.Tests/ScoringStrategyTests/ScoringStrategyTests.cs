using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smads.SweepDimension.Game.Components.GameOverStrategies;
using Smads.SweepDimension.Game.Components.Interfaces;
using Smads.SweepDimension.Game.Components.ScoringStrategies;

namespace Smads.SweepDimension.Game.Components.Tests.ScoringStrategyTests
{
    [TestClass]
    public class ScoringStrategyTests
    {
        [DataTestMethod]
        public void SpecificPieceVisibleGameOverStrategyReturnsCorrectValue()
        {
            var strategy = new TimeTakenScoringStrategy();

            var state = new GameState(null, null, null);

            state.StartGame();

            state.EndGame();

            Assert.AreEqual((int)(state.EndTime - state.StartTime).TotalSeconds,strategy.CalculateScore(state));
        }
    }
}
