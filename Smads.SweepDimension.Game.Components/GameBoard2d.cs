using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components
{
    public class GameBoard2d : IGameBoard
    {
        public IEnumerable<int> Dimensions { get; private set; }

        public int Sides { get; private set; }

        public int NoOfDimensions => Dimensions?.Count() ?? 0;

        private List<IGamePiece>[,] board;

        /// <summary>
        /// Create an instance of a Game Board class
        /// </summary>
        /// <param name="boardDimensions">An array containing the size of each dimension. 2 and 3 dimensions are supported.</param>
        /// <param name="pieceSides">Number of sides a tile in the board should have. 3,4 and 6 sided tiles are currently supported.</param>
        public GameBoard2d(IEnumerable<int> boardDimensions, int pieceSides)
        {
            if (boardDimensions.Any(d => d <= 0))
            {
                throw new ArgumentOutOfRangeException("boardDimensions", "Dimensions must be greater than 0.");
            }

            if (boardDimensions.Count() != 2)
            {
                throw new ArgumentOutOfRangeException("boardDimensions", "Must contain 2 dimensions.");
            }

            if (pieceSides != 3 && pieceSides != 4 && pieceSides != 6)
            {
                throw new ArgumentOutOfRangeException("pieceSides", "Only 3, 4 and 6 sided pieces are supported.");
            }

            Dimensions = boardDimensions;

            Sides = pieceSides;

            GenerateBoard();
        }

        /// <summary>
        /// Get the number of tiles that exist within the game board.
        /// </summary>
        /// <returns>Number of tiles the board comprises of.</returns>
        public int GetLocationCount()
        {
            return Dimensions.Aggregate(1, (x, y) => x * y);
        }

        public IEnumerable<IGamePiece> GetPiecesInLocation(IEnumerable<int> location)
        {
            var validLocation = IsLocationValid(location.ToArray());

            return board[validLocation[0], validLocation[1]].AsEnumerable() ?? new List<IGamePiece>().AsEnumerable();
        }

        public void PlacePiece(IGamePiece piece, IEnumerable<int> location)
        {
            var validLocation = IsLocationValid(location.ToArray());

            board[validLocation[0], validLocation[1]].Add(piece);
        }

        //public IEnumerable<IEnumerable<int>> GetAdjacentLocations(IEnumerable<int> location)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<IGamePiece> GetAdjacentPieces(IGamePiece piece)
        //{
        //    throw new NotImplementedException();
        //}

        //public void MovePiece(IGamePiece piece, IEnumerable<int> location)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemovePiece(IGamePiece piece, IEnumerable<int> location)
        //{
        //    throw new NotImplementedException();
        //}

        private void GenerateBoard()
        {
            int x, y;

            x = Dimensions.ElementAt(0);
            y = Dimensions.ElementAt(1);

            board = new List<IGamePiece>[x, y];

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    board[i, j] = new List<IGamePiece>();
                }
            }
        }

        private int[] IsLocationValid(int[] location)
        {
            if (location.Count() != 2)
            {
                throw new ArgumentOutOfRangeException("location", "Must contain 2 dimensions.");
            }

            if (location.Any(l => l < 0))
            {
                throw new ArgumentOutOfRangeException("location", "All points must have x and y coordinates of 0 or greater.");
            }

            if (location.ElementAt(0) >= Dimensions.ElementAt(0) || location.ElementAt(1) >= Dimensions.ElementAt(1))
            {
                throw new ArgumentOutOfRangeException("location", "All points must have x and y coordinates less than their respective maximums.");
            }

            return location;
        }
    }
}
