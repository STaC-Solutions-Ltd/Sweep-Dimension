using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smads.SweepDimension.Game.Components;
using System.Linq;
using Smads.SweepDimension.Game.Components.Interfaces;

namespace Smads.SweepDimension.Game.Components.Tests
{
    [TestClass]
    public class GameBoard3dTests
    {
        [DataTestMethod]
        [DataRow(new int[] {1 ,2, 1 })]
        [DataRow(new int[] {25 ,93, 23})]
        public void CanCreateGameBoard3dWithDifferentSizes(int[] boardSize)
        {
            var sides = 4;
            var dimensions = 3;

            var gameBoard = new GameBoard3d(boardSize, sides);

            Assert.AreEqual(dimensions, gameBoard.NoOfDimensions);
            Assert.AreEqual(sides, gameBoard.Sides);

            for (var i = 0; i < gameBoard.NoOfDimensions; i++)
            {
                Assert.AreEqual(boardSize[i], gameBoard.Dimensions.ElementAt(i));
            }
        }

        [DataTestMethod]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(6)]
        public void CanCreate3dGameBoardWithDifferentSidedExtrudedTile(int sides)
        {
            var boardSize = new int[] { 1, 1, 1 };
            var dimensions = 3;

            var gameBoard = new GameBoard3d(boardSize, sides);

            Assert.AreEqual(dimensions, gameBoard.NoOfDimensions);
            Assert.AreEqual(sides, gameBoard.Sides);

            for (var i = 0; i < gameBoard.NoOfDimensions; i++)
            {
                Assert.AreEqual(boardSize[i], gameBoard.Dimensions.ElementAt(i));
            }
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(7)]
        [DataRow(-1)]
        public void CannotCreate3dGameBoardWithDifferentSidedExtrudedTile(int sides)
        {
            var boardSize = new int[] { 1, 1, 1 };
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GameBoard3d(boardSize, sides));
        }

        [DataTestMethod]
        [DataRow(new int[] { -1, 2 })]
        [DataRow(new int[] { 1, 0 })]
        [DataRow(new int[] { 1, 2, -4 })]
        [DataRow(new int[] { -1, 0 })]
        public void CannotCreateGameBoardWithNegativeSize(int[] boardSize)
        {
            var sides = 4;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GameBoard3d(boardSize, sides));
        }

        [DataTestMethod]
        [DataRow(new int[] {  })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 5 })]
        [DataRow(new int[] { 1,2,3,4 })]
        public void CannotCreateGameBoard3dWithOtherDimensions(int[] boardSize)
        {
            var sides = 4;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GameBoard3d(boardSize, sides));
        }

        [DataTestMethod]
        [DataRow(new int[] {1 ,2, 1 }, 2)]
        [DataRow(new int[] { 10, 12, 2 }, 240)]
        [DataRow(new int[] { 5, 5, 5 }, 125)]
        public void CheckNoOfTiles(int[] dimensions, int noOfTiles )
        {
            var gameBoard = new GameBoard3d(dimensions, 4);

            Assert.AreEqual(noOfTiles, gameBoard.GetLocationCount());
        }
    }
}
