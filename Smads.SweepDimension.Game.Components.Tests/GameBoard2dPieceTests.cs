using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smads.SweepDimension.Game.Components.Interfaces;

namespace Smads.SweepDimension.Game.Components.Tests
{
    [TestClass]
    public class GameBoard2dPieceTests
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        [DataRow(new int[] { 5, 5 }, new int[] { 2, 3 })]
        public void CheckAddingAndFetching4SidedPiece(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(4, true, true);

            gameBoard.PlacePiece(piece, location);

            var resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(1, resultingPieces.Count());

            Assert.IsNotNull(resultingPieces.FirstOrDefault());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        public void CheckAddingAPiece(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(4, true, true);

            gameBoard.PlacePiece(piece, location);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 }, 0)]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 }, 6)]
        [DataRow(new int[] { 5, 5 }, new int[] { 2, 3 }, 3)]
        public void CheckMultipleAddingAndFetching3SidedPiece(int[] dimensions, int[] location, int noOfPieces)
        {
            var gameBoard = new GameBoard2d(dimensions, 3);

            var pieces = new List<IGamePiece>();

            for (var i = 0; i < noOfPieces; i++)
            {
                var piece = new GamePiece(3, true, true);

                gameBoard.PlacePiece(piece, location);
            }

            var resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(noOfPieces, resultingPieces.Count());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { -1, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 12 })]
        public void CheckAddingAPieceOutsideTheBoardIsHandled(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(4, true, true);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameBoard.PlacePiece(piece, location));
        }
    }
}
