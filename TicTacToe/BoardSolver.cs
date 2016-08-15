using System.Collections.Generic;

namespace TicTacToe
{
    /// <summary>
    /// Implements the MiniMax algorithm for finding the best TicTacToe moves.
    /// </summary>
    class BoardSolver
    {
        /// <summary>
        /// Returns all unoccupied fields
        /// </summary>
        /// <param name="board">the game board</param>
        /// <returns>List of all unoccupied field positions</returns>
        private static List<Vec2> GetPossibleMovements(Board board)
        {
            var possibleMovements = new List<Vec2>();

            for (int y = 0; y < board.BoardSize; y++)
            {
                for (int x = 0; x < board.BoardSize; x++)
                {
                    if (board[x, y] == null)
                        possibleMovements.Add(new Vec2(x, y));
                }
            }

            return possibleMovements;
        }

        /// <summary>
        /// Compute the MiniMax score
        /// </summary>
        /// <param name="board">the board with it`s current state</param>
        /// <param name="playerToWin">The player that we want to win</param>
        /// <returns>minimax score</returns>
        private static int GetMiniMaxScore(Board board, int depth, IPlayer playerToWin)
        {
            // Check if the game is over - breaks the recursion.
            if (IsGameOver(board, depth, playerToWin, out var score))
                return score;

            // Get all possible movements
            var possibleMovements = GetPossibleMovements(board);

            // we're in the maximizing mode
            if (board.CurrentPlayerToMove == playerToWin)
            {
                var bestScore = int.MinValue;
                for (int i = 0; i < possibleMovements.Count; i++)
                {
                    // Enumerate over all the possible movements and 
                    // create copies of the current board, simulate the possible move
                    // and compute it`s score.

                    var possibleBoard = new Board(board);
                    possibleBoard.MakeMove(possibleMovements[i]);

                    // if the score is better than the previous, update it
                    var possibleScore = GetMiniMaxScore(possibleBoard, depth+1, playerToWin);
                    if (possibleScore > bestScore)
                        bestScore = possibleScore;
                }
                return bestScore;
            }
            else
            {
                // We'er in the minimizing mode
                // same as above
                var bestScore = int.MaxValue;
                for (int i = 0; i < possibleMovements.Count; i++)
                {
                    var possibleBoard = new Board(board);
                    possibleBoard.MakeMove(possibleMovements[i]);

                    var possibleScore = GetMiniMaxScore(possibleBoard, depth+1, playerToWin);
                    if (possibleScore < bestScore)
                        bestScore = possibleScore;
                }

                return bestScore;
            }
        }

        /// <summary>
        /// Returns the board state in points.
        /// </summary>
        /// <param name="board">board to check</param>
        /// <param name="playerToWin">the player that we want to win</param>
        /// <param name="score">board score</param>
        /// <returns>true if game is over</returns>
        private static bool IsGameOver(Board board, int depth, IPlayer playerToWin, out int score)
        {
            score = 0;
            if (board.IsFinished)
            {
                if (board.Winner != null)
                {
                    if (board.Winner == playerToWin)
                            score = 10 - depth;
                        else
                            score = depth - 10;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the position of the best cell to occupy 
        /// for the player that is in turn
        /// </summary>
        /// <param name="board">board state to return the best move for</param>
        /// <returns>position of the best cell to occupy</returns>
        public static Vec2 GetBestMove(Board board)
        {
            var nextPlayer = board.CurrentPlayerToMove;
            var possibleMovements = GetPossibleMovements(board);

            var bestMovementScore = int.MinValue;
            var bestMovementIndex = -1;

            // Go over all possible movements, simulate them and compute the scores.
            for (int i = 0; i < possibleMovements.Count; i++)
            {
                var possibleBoard = new Board(board);
                possibleBoard.MakeMove(possibleMovements[i]);
                var score = GetMiniMaxScore(possibleBoard, 0, board.CurrentPlayerToMove);

                if (score > bestMovementScore)
                {
                    bestMovementScore = score;
                    bestMovementIndex = i;
                }
            }

            // return the movement with the best score
            return possibleMovements[bestMovementIndex];
        }
    }
}
