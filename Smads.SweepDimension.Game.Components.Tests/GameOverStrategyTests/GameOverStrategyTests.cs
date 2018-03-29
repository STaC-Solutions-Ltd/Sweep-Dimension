using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smads.SweepDimension.Game.Components.GameOverStrategies;
using Smads.SweepDimension.Game.Components.Interfaces;

namespace Smads.SweepDimension.Game.Components.Tests.GameOverStrategyTests
{
    [TestClass]
    public class GameOverStrategyTests
    {
        [DataTestMethod]
        public void SpecificPieceVisibleGameOverStrategyReturnsCorrectValue()
        {
            var pieces = new List<IGamePiece>();

            pieces.Add(new GamePiece(1, "Test", null, true));
            pieces.Add(new GamePiece(2, "Test", null, false));
            pieces.Add(new GamePiece(3, "Test", null, true));

            var strategy = new SpecificPieceVisibleGameOverStrategy(1);

            var state = new GameState(null, pieces, null);

            Assert.AreEqual(true,strategy.IsCriteriaMet(state));
        }

        [DataTestMethod]
        public void SpecificPieceInvisibleGameOverStrategyReturnsCorrectValue()
        {
            var pieces = new List<IGamePiece>();

            pieces.Add(new GamePiece(1, "Test", null, false));
            pieces.Add(new GamePiece(2, "Test", null, false));
            pieces.Add(new GamePiece(3, "Test", null, true));

            var strategy = new SpecificPieceVisibleGameOverStrategy(1);

            var state = new GameState(null, pieces, null);

            Assert.AreEqual(false, strategy.IsCriteriaMet(state));
        }

        [DataTestMethod]
        public void OnlySpecificPiecesRemainingGameOverStrategyReturnsCorrectValue()
        {
            var pieces = new List<IGamePiece>();

            pieces.Add(new GamePiece(1, "Test", null, false));
            pieces.Add(new GamePiece(2, "Test", null, true));
            pieces.Add(new GamePiece(3, "Test", null, true));

            var strategy = new OnlySpecificPiecesRemainingGameOverStrategy(1);

            var state = new GameState(null, pieces, null);

            Assert.AreEqual(true, strategy.IsCriteriaMet(state));
        }

        [DataTestMethod]
        public void OnlySpecificPiecesRemainingMultipleGameOverStrategyReturnsCorrectValue()
        {
            var pieces = new List<IGamePiece>();

            pieces.Add(new GamePiece(1, "Test", null, false));
            pieces.Add(new GamePiece(2, "Test", null, true));
            pieces.Add(new GamePiece(3, "Test", null, true));
            pieces.Add(new GamePiece(1, "Test", null, false));

            var strategy = new OnlySpecificPiecesRemainingGameOverStrategy(1);

            var state = new GameState(null, pieces, null);

            Assert.AreEqual(true, strategy.IsCriteriaMet(state));
        }

        [DataTestMethod]
        public void OnlyPartialSpecificPiecesRemainingMultipleGameOverStrategyReturnsCorrectValue()
        {
            var pieces = new List<IGamePiece>();

            pieces.Add(new GamePiece(1, "Test", null, false));
            pieces.Add(new GamePiece(2, "Test", null, true));
            pieces.Add(new GamePiece(3, "Test", null, true));
            pieces.Add(new GamePiece(1, "Test", null, true));

            var strategy = new OnlySpecificPiecesRemainingGameOverStrategy(1);

            var state = new GameState(null, pieces, null);

            Assert.AreEqual(false, strategy.IsCriteriaMet(state));
        }

        [DataTestMethod]
        public void NoSpecificPiecesRemainingMultipleGameOverStrategyReturnsCorrectValue()
        {
            var pieces = new List<IGamePiece>();

            pieces.Add(new GamePiece(2, "Test", null, true));
            pieces.Add(new GamePiece(3, "Test", null, true));

            var strategy = new OnlySpecificPiecesRemainingGameOverStrategy(1);

            var state = new GameState(null, pieces, null);

            Assert.AreEqual(true, strategy.IsCriteriaMet(state));
        }
    }
}
