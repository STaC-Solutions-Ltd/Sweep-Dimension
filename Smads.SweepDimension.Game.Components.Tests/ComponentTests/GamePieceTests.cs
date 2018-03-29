using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smads.SweepDimension.Game.Components.MovementStrategies;

namespace Smads.SweepDimension.Game.Components.Tests
{
    [TestClass]
    public class GamePieceTests
    {
        [DataTestMethod]
        [DataRow(1, "Test", true)]
        [DataRow(4, "Other", true)]
        [DataRow(6, "Type", false)]
        [DataRow(4, "Name", false)]
        public void CanCreateGamePiece(int typeID, string typeName,bool visible)
        {
            var piece = new GamePiece(typeID, typeName, new NoMovementStrategy(), visible);

            Assert.AreEqual(typeID, piece.TypeID);
            Assert.AreEqual(typeName, piece.TypeName);
            Assert.AreEqual(visible, piece.Visible);
        }

        [DataTestMethod]
        [DataRow(1, "Test", true)]
        [DataRow(4, "Other", true)]
        [DataRow(6, "Type", false)]
        [DataRow(4, "Name", false)]
        public void CanToggleVisibility(int typeID, string typeName, bool visible)
        {
            var piece = new GamePiece(typeID, typeName, new NoMovementStrategy(), visible);

            piece.ToggleVisibility();

            Assert.AreEqual(!visible, piece.Visible);
            Assert.AreEqual(typeID, piece.TypeID);
            Assert.AreEqual(typeName, piece.TypeName);
        }

        [DataTestMethod]
        [DataRow(1, "Test", true)]
        [DataRow(4, "Other", true)]
        [DataRow(6, "Type", false)]
        [DataRow(4, "Name", false)]
        public void CanGetPiecesMoves(int typeID, string typeName, bool visible)
        {
            var piece = new GamePiece(typeID, typeName, new NoMovementStrategy(), visible); ;

            var availableMoves = piece.LegalMoves();

            Assert.IsNotNull(availableMoves);
            Assert.AreEqual(0, availableMoves.Count());
        }
    }
}
