using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smads.SweepDimension.Game.Components.Interfaces;
using Smads.SweepDimension.Game.Components.MovementStrategies;

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

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            gameBoard.PlacePiece(piece, location);

            var resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(1, resultingPieces.Count());

            Assert.IsNotNull(resultingPieces.FirstOrDefault());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        [DataRow(new int[] { 5, 5 }, new int[] { 2, 3 })]
        public void CheckAddingAndFetching4SidedPieceMultipleTimes(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            gameBoard.PlacePiece(piece, location);

            var resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(1, resultingPieces.Count());

            Assert.IsNotNull(resultingPieces.FirstOrDefault());

            resultingPieces = gameBoard.GetPiecesInLocation(location);

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

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

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
                var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

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

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameBoard.PlacePiece(piece, location));
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        public void CheckAddingFetchingAndRemovingAPiece(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            gameBoard.PlacePiece(piece, location);

            var resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(1, resultingPieces.Count());

            Assert.IsNotNull(resultingPieces.FirstOrDefault());

            gameBoard.RemovePiece(piece);

            resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(0, resultingPieces.Count());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 1 }, new int[] { 0, 0 }, 0)]

        [DataRow(new int[] { 10, 12 }, new int[] { 0, 0 }, 3)]
        [DataRow(new int[] { 5, 5 }, new int[] { 4, 4 }, 3)]
        [DataRow(new int[] { 5, 5 }, new int[] { 0, 4 }, 3)]
        [DataRow(new int[] { 5, 5 }, new int[] { 4, 0 }, 3)]

        [DataRow(new int[] { 10, 12 }, new int[] { 1, 0 }, 5)]
        [DataRow(new int[] { 5, 5 }, new int[] { 3, 4 }, 5)]
        [DataRow(new int[] { 5, 5 }, new int[] { 0, 3 }, 5)]
        [DataRow(new int[] { 5, 5 }, new int[] { 4, 1 }, 5)]

        [DataRow(new int[] { 5, 5 }, new int[] { 2, 2 }, 8)]
        public void GetAdjacentPieces(int[] dimensions, int[] location, int expected)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            int x, y;

            x = dimensions[0];
            y = dimensions[1];

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    gameBoard.PlacePiece(new GamePiece(-1, "Test", new NoMovementStrategy(), true), new[] { i, j });
                }
            }

            var piece = gameBoard.GetPiecesInLocation(location).FirstOrDefault();

            var adjacentLocations = gameBoard.GetAdjacentPieces(piece);

            Assert.AreEqual(expected, adjacentLocations.Count());
        }


        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        public void GetPiecesInLocation(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            gameBoard.PlacePiece(piece, location);

            var pieces = gameBoard.GetPiecesInLocation(location);

            Assert.AreSame(piece, pieces.FirstOrDefault());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        public void GetPiecesLocation(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            gameBoard.PlacePiece(piece, location);

            var piecesLocation = gameBoard.GetPiecesLocation(piece);

            Assert.AreEqual(location[0], piecesLocation.ElementAt(0));
            Assert.AreEqual(location[1], piecesLocation.ElementAt(1));
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 }, new int[] { 0, 0 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 }, new int[] { 2, 3 })]
        public void CheckAddingFetchingAndMovingAPiece(int[] dimensions, int[] location, int[] destination)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            gameBoard.PlacePiece(piece, location);

            var resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(1, resultingPieces.Count());

            Assert.IsNotNull(resultingPieces.FirstOrDefault());

            gameBoard.MovePiece(piece, destination);

            resultingPieces = gameBoard.GetPiecesInLocation(location);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(0, resultingPieces.Count());

            resultingPieces = gameBoard.GetPiecesInLocation(destination);

            Assert.IsNotNull(resultingPieces);

            Assert.AreEqual(1, resultingPieces.Count());

            Assert.IsNotNull(resultingPieces.FirstOrDefault());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        [DataRow(new int[] { 5, 5 }, new int[] { 2, 3 })]
        public void CannotAddSamePieceTwice(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            gameBoard.PlacePiece(piece, location);

            Assert.ThrowsException<ArgumentException>(() => gameBoard.PlacePiece(piece, location));
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 10, 12 }, new int[] { 5, 3 })]
        [DataRow(new int[] { 5, 5 }, new int[] { 2, 3 })]
        public void CannotRemovePieceThatIsNotAdded(int[] dimensions, int[] location)
        {
            var gameBoard = new GameBoard2d(dimensions, 4);

            var piece = new GamePiece(-1, "Test", new NoMovementStrategy(), true);

            Assert.ThrowsException<ArgumentException>(() => gameBoard.RemovePiece(piece));
        }
    }
}
