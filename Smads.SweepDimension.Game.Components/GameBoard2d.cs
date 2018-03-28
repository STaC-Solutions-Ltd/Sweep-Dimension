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

        private List<IGamePiece> PiecesOnBoard;

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

        public IEnumerable<IEnumerable<int>> GetAdjacentLocations(IEnumerable<int> location)
        {
            var verifiedLocation = IsLocationValid(location.ToArray());

            return getAdjacentLocations(verifiedLocation);
        }

        /// <summary>
        /// Add piece to a specified location.
        /// </summary>
        /// <param name="piece">Game piece to add to board.</param>
        /// <param name="location">Location to add game piece.</param>
        public void PlacePiece(IGamePiece piece, IEnumerable<int> location)
        {
            if (PiecesOnBoard.Contains(piece))
            {
                throw new ArgumentException("Piece already added to board.", "Piece");
            }

            var validLocation = IsLocationValid(location.ToArray());

            AddPiece(piece, validLocation);
        }

        /// <summary>
        /// Get the location of a specific piece
        /// </summary>
        /// <param name="piece">Piece to find the location for</param>
        /// <returns>The location of the piece</returns>
        public IEnumerable<int> GetPiecesLocation(IGamePiece piece)
        {
            if (!PiecesOnBoard.Contains(piece))
            {
                throw new ArgumentException("Piece not currently on the board.", "Piece");
            }

            return FindPiece(piece);
        }

        /// <summary>
        /// Get the game pieces that are in a specified location.
        /// </summary>
        /// <param name="location">Location to get pieces from.</param>
        /// <returns>List of pieces in location</returns>
        public IEnumerable<IGamePiece> GetPiecesInLocation(IEnumerable<int> location)
        {
            var validLocation = IsLocationValid(location.ToArray());

            return GetPieces( validLocation[0], validLocation[1]);
        }

        /// <summary>
        /// Get all pieces that are adjacent to the current piece
        /// </summary>
        /// <param name="piece">Piece to search next to</param>
        /// <returns>List of game pieces</returns>
        public IEnumerable<IGamePiece> GetAdjacentPieces(IGamePiece piece)
        {
            if (!PiecesOnBoard.Contains(piece))
            {
                throw new ArgumentException("Piece not currently on the board.", "Piece");
            }

            return getAdjacentPieces(piece);
        }

        /// <summary>
        /// Move a specified piece from a source location to a destination location.
        /// </summary>
        /// <param name="piece">Piece to move</param>
        /// <param name="location">Location to move the piece from</param>
        /// <param name="destLocation">Location to move the piece to</param>
        public void MovePiece(IGamePiece piece, IEnumerable<int> destLocation)
        {
            if (!PiecesOnBoard.Contains(piece))
            {
                throw new ArgumentException("Piece not currently on the board.", "Piece");
            }

            var destinationLocation = IsLocationValid(destLocation.ToArray());

            DeletePiece(piece);
            AddPiece(piece, destinationLocation);
        }

        /// <summary>
        /// Remove piece from board
        /// </summary>
        /// <param name="piece">Piece to remove from the board</param>
        public void RemovePiece(IGamePiece piece)
        {
            if (!PiecesOnBoard.Contains(piece))
            {
                throw new ArgumentException("Piece not currently on the board.", "Piece");
            }

            DeletePiece(piece);
        }

        #region Private Methods

        /// <summary>
        /// Create the available locations on the board
        /// </summary>
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

            PiecesOnBoard = new List<IGamePiece>();
        }

        /// <summary>
        /// Check location is valid
        /// </summary>
        /// <param name="location">Location to verify</param>
        /// <returns>Location after is has been verified</returns>
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

        private List<int[]> getAdjacentLocations(int[] location)
        {
            var adjacentLocations = new List<int[]>();

            switch (Sides)
            {
                case 3:

                    break;
                case 4:

                    adjacentLocations.Add(new[] { location[0] - 1, location[1] - 1 });
                    adjacentLocations.Add(new[] { location[0] - 1, location[1] - 0 });
                    adjacentLocations.Add(new[] { location[0] - 1, location[1] + 1 });

                    adjacentLocations.Add(new[] { location[0] - 0, location[1] - 1 });
                    adjacentLocations.Add(new[] { location[0] - 0, location[1] + 1 });

                    adjacentLocations.Add(new[] { location[0] + 1, location[1] - 1 });
                    adjacentLocations.Add(new[] { location[0] + 1, location[1] - 0 });
                    adjacentLocations.Add(new[] { location[0] + 1, location[1] + 1 });

                    adjacentLocations.RemoveAll(l => l.Any(v => v < 0) || l[0] >= Dimensions.ElementAt(0) || l[1] >= Dimensions.ElementAt(1));

                    break;
                case 6:

                    break;
                default:
                    throw new InvalidOperationException();
            }

            return adjacentLocations;
        }

        private List<IGamePiece> getAdjacentPieces(IGamePiece piece)
        {
            var location = FindPiece(piece);

            var otherLocations = getAdjacentLocations(location);

            var adjacentPieces = new List<IGamePiece>();

            foreach(var otherLocation in otherLocations)
            {
                adjacentPieces.AddRange(GetPieces(otherLocation[0], otherLocation[1]));
            }

            return adjacentPieces;
        }

        private List<IGamePiece> GetPieces(int x, int y)
        {
            return board[x, y];
        }

        private int[] FindPiece(IGamePiece piece)
        {
            int x, y;

            x = Dimensions.ElementAt(0);
            y = Dimensions.ElementAt(1);

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (board[i, j].Contains(piece))
                    {
                        return new[] { i, j };
                    }
                }
            }

            return null;
        }

        private void AddPiece(IGamePiece piece, int[] location)
        {
            PiecesOnBoard.Add(piece);

            board[location[0], location[1]].Add(piece);
        }

        private void DeletePiece(IGamePiece piece)
        {
            var location = FindPiece(piece);

            board[location[0], location[1]].Remove(piece);

            PiecesOnBoard.Remove(piece);
        }

        #endregion
    }
}
