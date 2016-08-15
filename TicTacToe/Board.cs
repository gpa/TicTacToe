using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{

    /// <summary>
    /// Class representing the TicTacToe Game.
    /// </summary>
    public class Board
    {

        /// <summary>
        /// Cells of the game grid stored as a 2D array
        /// </summary>
        private IPlayer[,] _board;

        /// <summary>
        /// Holds the winner of the game
        /// Only valid if the game has been finished.
        /// Null in case of a Tie.
        /// </summary>
        private IPlayer _winner;

        /// <summary>
        /// Contains all the playing entities.
        /// </summary>
        public IReadOnlyList<IPlayer> Players { get; private set; }

        /// <summary>
        /// The board grid size in cells.
        /// </summary>
        public int BoardSize { get; private set; }

        /// <summary>
        /// How many symbols in a row does one player need to win?
        /// </summary>
        public int InRowToWin { get; private set; }

        /// <summary>
        /// Whether the game has finished.
        /// </summary>
        public bool IsFinished { get; private set; }

        /// <summary>
        /// The Player that has its turn.
        /// </summary>
        public IPlayer CurrentPlayerToMove { get; private set; }

        /// <summary>
        /// The next player to move after current turn
        /// </summary>
        public IPlayer NextPlayerToMove
        {
            get
            {
                var players = (List<IPlayer>)Players;
                var nextPlayer = players.IndexOf(CurrentPlayerToMove) + 1;
                if (nextPlayer >= Players.Count)
                    return Players[0];

                return Players[nextPlayer];
            }
        }

        /// <summary>
        /// Stores the winner of the game.
        /// Only valid if <see cref="IsFinished"/> is true
        /// Null on tie.
        /// </summary>
        public IPlayer Winner
        {
            get => _winner;
            private set
            {
                if (IsFinished)
                    throw new InvalidOperationException("Winner cannot be set because the game has been finished.");

                _winner = value;
                IsFinished = true;
            }
        }

        /// <summary>
        /// Get the player that occupies the given grid cell.
        /// </summary>
        /// <param name="x">Position of the cell on X Axis</param>
        /// <param name="y">Position of the cell on Y Axis</param>
        /// <returns></returns>
        public IPlayer this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= BoardSize)
                    throw new ArgumentOutOfRangeException(nameof(x));
                if (y < 0 || y >= BoardSize)
                    throw new ArgumentOutOfRangeException(nameof(y));

                return _board[x, y];
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks> Only supports two players and a 3x3 board size although the 
        /// internal implementation supports unlimited number of players and grid size. </remarks>
        /// <param name="playerA">Player A</param>
        /// <param name="playerB">Player B</param>
        public Board(IPlayer playerA, IPlayer playerB)
        {
            BoardSize = 3;
            InRowToWin = 3;
            _board = new IPlayer[BoardSize, BoardSize];
            Players = new List<IPlayer>() { playerA, playerB };
            CurrentPlayerToMove = playerA;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="board">The instance to copy</param>
        public Board(Board board)
        {
            _board = board._board.Clone() as IPlayer[,];
            BoardSize = board.BoardSize;
            InRowToWin = board.InRowToWin;
            Players = board.Players.ToList();
            CurrentPlayerToMove = board.CurrentPlayerToMove;
        }

        /// <summary>
        /// Makes the move with the given <see cref="CurrentPlayerToMove"/> on the given Position.
        /// </summary>
        /// <param name="position">The position the player wishes to occupy.</param>
        public void MakeMove(Vec2 position)
        {
            var x = position.X;
            var y = position.Y;

            if (x >= BoardSize || x < 0)
                throw new ArgumentOutOfRangeException(nameof(position.Y));

            if (y >= BoardSize || y < 0)
                throw new ArgumentOutOfRangeException(nameof(position.X));

            if (IsFinished)
                throw new InvalidOperationException("Can't make a move because the game has been finished.");

            if (_board[x, y] != null)
                throw new InvalidOperationException("Can't make a move because the requested field is already occupied.");

            _board[x, y] = CurrentPlayerToMove;
            CurrentPlayerToMove = NextPlayerToMove;
            UpdateGameState();
        }

        /// <summary>
        /// Checks for gameover, win and ties.
        /// </summary>
        private void UpdateGameState()
        {
            // Check every X and Y axis
            for (var i = 0; i < BoardSize; ++i)
            {
                var xAxisWinner = GetAxisWinner(new Vec2(0, i), new Vec2(1, 0));
                var yAxisWinner = GetAxisWinner(new Vec2(i, 0), new Vec2(0, 1));

                if (xAxisWinner != null)
                {
                    Winner = xAxisWinner;
                    return;
                }

                if (yAxisWinner != null)
                {
                    Winner = yAxisWinner;
                    return;
                }
            }

            // Check the diagonal and anti-diagonal axis
            var diagonalWinner = GetAxisWinner(new Vec2(0, 0), new Vec2(1, 1));
            var diagonalAltWinner = GetAxisWinner(new Vec2(BoardSize - 1, 0), new Vec2(-1, 1));

            if (diagonalAltWinner != null)
            {
                Winner = diagonalAltWinner;
                return;
            }

            if (diagonalWinner != null)
            {
                Winner = diagonalWinner;
                return;
            }

            // Check if all fiels are occupied, if so, we have a tie.
            foreach (var player in _board)
            {
                if (player == null)
                    return;
            }

            IsFinished = true;
        }

        /// <summary>
        /// Searches for a symbol that occures in row <see cref="InRowToWin"/> times.
        /// It starts on the cell given by <paramref name="position"/> and then moves
        /// by the delta of <paramref name="direction" />
        /// For Example if the position is 0,0 and direction 1,0, we check the cells 0,0;1,0;2,0 in the 3x3 grid.
        /// Returns null if no symbol occures <see cref="InRowToWin"/> times, otherwise returns the player of the winning symbol.
        /// </summary>
        /// <param name="position">the starting cell position</param>
        /// <param name="direction">normalized search direction</param>
        /// <returns>Winning player, or null on tie</returns>
        private IPlayer GetAxisWinner(Vec2 position, Vec2 direction)
        {
            var count = 0;
            var lastPlayer = default(IPlayer);

            var x = position.X;
            var y = position.Y;

            // As long as we're not out of bounds
            while (x < BoardSize && y < BoardSize && x >= 0 && y >= 0)
            {
                // count the occurence of symbols
                var currentPlayer = _board[x, y];
                if (currentPlayer != lastPlayer)
                {
                    // new symbol takes over! Reset the counter
                    count = 1;
                    lastPlayer = currentPlayer;
                }
                else
                {
                    if (currentPlayer == null)
                    {
                        // Emty cell and we still didn't hit the InRowToWin minimum!
                        // reset the counter.
                        count = 0;
                        lastPlayer = null;
                    }
                    else
                    {
                        // Increase count since the symbol matches the previous one
                        count++;
                        if (count >= InRowToWin)
                            return currentPlayer; // we got a winner.
                    }
                }

                // move along the given direction
                x = x + direction.X;
                y = y + direction.Y;
            }

            return null;
        }
    }
}
