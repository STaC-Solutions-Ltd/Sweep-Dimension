using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Smads.SweepDimension.Game.Components.Tests
{
    [TestClass]
    public class GamePieceTests
    {
        [DataTestMethod]
        [DataRow(3, true, true)]
        [DataRow(4, false, true)]
        [DataRow(6, true, false)]
        [DataRow(4, false, false)]
        public void CanCreateGamePiece(int sides, bool mainState,bool visible)
        {
            var piece = new GamePiece(sides, mainState, visible);

            Assert.AreEqual(sides, piece.Sides);
            Assert.AreEqual(mainState, piece.MainState);
            Assert.AreEqual(visible, piece.Visible);
        }

        [DataTestMethod]
        [DataRow(3, true, true)]
        [DataRow(4, false, true)]
        public void CanToggleState(int sides, bool mainState, bool visible)
        {
            var piece = new GamePiece(sides, mainState, visible);

            piece.ToggleState();

            Assert.AreEqual(!mainState, piece.MainState);
        }

        [DataTestMethod]
        [DataRow(3, true, false)]
        [DataRow(4, false, true)]
        public void CanToggleVisibility(int sides, bool mainState, bool visible)
        {
            var piece = new GamePiece(sides, mainState, visible);

            piece.ToggleVisibility();

            Assert.AreEqual(!visible, piece.Visible);
        }
    }
}
