using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    [TestClass]
    public class BoardTests
    {
        private readonly Player PlayerA = new Player('X', "Player X");
        private readonly Player PlayerB = new Player('O', "Player O");

        [TestMethod]
        public void Constructor_SetsCorrectlyProperties()
        {
            var players = new List<IPlayer>() { PlayerA, PlayerB };
            var board = new Board(PlayerA, PlayerB);

            Assert.AreEqual(2, board.Players.Count);
            Assert.AreEqual(3, board.BoardSize);
            Assert.IsFalse(board.IsFinished);
            Assert.IsNull(board.Winner);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Can't make a move because the requested field is already occupied.")]
        public void MakeMove_ThrowsWhenMakingMoveOnOccupiedField()
        {
            var board = new Board(PlayerA, PlayerB);
            board.MakeMove(new Vec2(2, 0));
            board.MakeMove(new Vec2(2, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Can't make a move because the game has already finished.")]
        public void MakeMove_ThrowsWhenMakingMoveOnAFinishedGame()
        {
            var board = new Board(PlayerA, PlayerB);
            board.MakeMove(new Vec2(0, 0));
            board.MakeMove(new Vec2(0, 1));
            board.MakeMove(new Vec2(1, 0));
            board.MakeMove(new Vec2(1, 1));
            board.MakeMove(new Vec2(2, 0));
            board.MakeMove(new Vec2(2, 2));
        }

        [TestMethod]
        public void MakeMove_DetectsDiagonalWin()
        {
            var board = new Board(PlayerA, PlayerB);

            board.MakeMove(new Vec2(0, 0));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(1, 0));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(1, 1));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(2, 0));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(2, 2));
            Assert.IsTrue(board.IsFinished);
            Assert.AreEqual(PlayerA, board.Winner);
        }

        [TestMethod]
        public void MakeMove_DetectsXWin()
        {
            var board = new Board(PlayerA, PlayerB);

            board.MakeMove(new Vec2(0, 1));
            Assert.IsFalse(board.IsFinished);

            board.MakeMove(new Vec2(0, 2));
            Assert.IsFalse(board.IsFinished);

            board.MakeMove(new Vec2(1, 1));
            Assert.IsFalse(board.IsFinished);

            board.MakeMove(new Vec2(1, 2));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(2, 1));
            Assert.IsTrue(board.IsFinished);
            Assert.AreEqual(PlayerA, board.Winner);
        }

        [TestMethod]
        public void MakeMove_DetectsYWin()
        {
            var board = new Board(PlayerA, PlayerB);

            board.MakeMove(new Vec2(1, 0));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(0, 0));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(2, 0));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(0, 1));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(2, 1));
            Assert.IsFalse(board.IsFinished);
            board.MakeMove(new Vec2(0, 2));
            Assert.IsTrue(board.IsFinished);
            Assert.AreEqual(PlayerB, board.Winner);
        }

        [TestMethod]
        public void MakeMove_DetectsTie()
        {
            var board = new Board(PlayerA, PlayerB);

            board.MakeMove(new Vec2(0, 0)); // x
            board.MakeMove(new Vec2(0, 1)); // o
            board.MakeMove(new Vec2(0, 2)); // x
            board.MakeMove(new Vec2(1, 1)); // o
            board.MakeMove(new Vec2(1, 0)); // x
            board.MakeMove(new Vec2(2, 0)); // o
            board.MakeMove(new Vec2(2, 1)); // x
            board.MakeMove(new Vec2(1, 2)); // o
            board.MakeMove(new Vec2(2, 2)); // x

            Assert.IsTrue(board.IsFinished);
            Assert.IsNull(board.Winner);
        }
    }
}
