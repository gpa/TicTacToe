using System;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// Main form of the game
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// Player 1
        /// </summary>
        private Player _playerA = new Player('X', "Spieler X");

        /// <summary>
        /// Player 2
        /// </summary>
        private Player _playerB = new Player('O', "Spieler O");

        /// <summary>
        /// The TicTacToe game
        /// </summary>
        private Board _board;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        /// <summary>
        /// Reset the TicTacToe board
        /// If the AI is enabled, determine whether AI begins.
        /// </summary>
        private void ResetGame()
        {
            btn00.Text = btn01.Text = btn02.Text = btn10.Text = btn11.Text = btn12.Text
            = btn20.Text = btn21.Text = btn22.Text = "";

            _board = new Board(_playerA, _playerB);
            if (aiCheckbox.Checked)
            {
                // If AI is enabled make it begin with 50% probability
                Random rnd = new Random();
                var random = rnd.Next(1, 3);
                if (random == 2)
                {
                    _board = new Board(_playerB, _playerA);
                    // Make move on a random position
                    var x = rnd.Next(0, 3);
                    var y = rnd.Next(0, 3);
                    AIMakeMove(new Vec2(x, y));
                }
            }

            UpdateStats();
        }

        /// <summary>
        /// Make the move on board
        /// </summary>
        /// <param name="move">move to make</param>
        /// <returns>true if successful</returns>
        private bool MakeMove(Vec2 move)
        {
            if (_board[move.X, move.Y] != null)
                return false;

            _board.MakeMove(move);
            return true;
        }

        /// <summary>
        /// Reset scores of the players
        /// </summary>
        private void ResetScores()
        {
            _playerA.Score = 0;
            _playerB.Score = 0;
            UpdateStats();
        }

        /// <summary>
        /// Determine if game is over and display a message if so.
        /// </summary>
        private void CheckGameState()
        {
            if (_board.IsFinished)
            {
                if (_board.Winner != null)
                {
                    var winner = (Player)_board.Winner;
                    MessageBox.Show(winner.Name + " hat gewonnen!");
                    winner.Score++;
                }
                else
                    MessageBox.Show("Es ist unentschieden!");

                UpdateStats();
            }
        }

        /// <summary>
        /// Called when the TicTacToe cel is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMakeMove(object sender, System.EventArgs e)
        {
            if (_board.IsFinished)
                return;

            // Determine the button that the event is comming from
            var button = (Button)sender;
            var cx = ((string)button.Tag)[0];
            var cy = ((string)button.Tag)[1];

            // Determine the cell position from the button`s TAG
            var x = int.Parse(cx.ToString());
            var y = int.Parse(cy.ToString());

            // Save the player that will make a move
            var player = _board.CurrentPlayerToMove;

            // Make the move and update the UI if the move is successful
            if (MakeMove(new Vec2(x, y)))
            {
                button.Text = player.Symbol.ToString();
                CheckGameState();

                // make computer move if neccessary
                if (!_board.IsFinished && aiCheckbox.Checked)
                {
                    AIMakeMove(null);
                    CheckGameState();
                }
            }
        }

        /// <summary>
        /// Fired when the play again button is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">optional parameters</param>
        private void OnNewGameButtonClick(object sender, EventArgs e)
        {
            ResetGame();
        }

        /// <summary>
        /// Make the ai move and update the UI accordingly
        /// </summary>
        /// <param name="move">optional predetermined move</param>
        private void AIMakeMove(Vec2 move)
        {
            var AIPlayer = _board.CurrentPlayerToMove;

            if (move == null)
            {
                move = BoardSolver.GetBestMove(_board);
            }

            _board.MakeMove(move);

            // Determine the UI button to update
            var movementButtonId = move.X.ToString() + move.Y.ToString();
            var buttons = new[] { btn00, btn10, btn20, btn01, btn11, btn21, btn02, btn12, btn22 };
            var foundButton = buttons.First(btn => (string)btn.Tag == movementButtonId);
            foundButton.Text = AIPlayer.Symbol.ToString();
        }

        /// <summary>
        /// Update UI stats
        /// </summary>
        private void UpdateStats()
        {
            playerAScoreLabel.Text = _playerA.Name + " - " + _playerA.Score.ToString();
            playerBScoreLabel.Text = _playerB.Name + " - " + _playerB.Score.ToString();
        }

        /// <summary>
        /// Fired when the reset scores button is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">optional parameters</param>
        private void OnResetPointsButtonClicked(object sender, EventArgs e)
        {
            ResetScores();
        }

        /// <summary>
        /// Fired when the player`s 1 name is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">optional parameters</param>
        private void OnPlayerANameClicked(object sender, EventArgs e)
        {
            // show dialog and update name
            string newPlayerName = Prompt.ShowDialog("Spielername ändern", "Spielername ändern");
            _playerA.Name = newPlayerName;
            UpdateStats();
        }

        /// <summary>
        /// Fired when the player`s 2 name is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">optional parameters</param>
        private void OnPlayerBNameClicked(object sender, EventArgs e)
        {
            string newPlayerName = Prompt.ShowDialog("Spielername ändern", "Spielername ändern");
            _playerB.Name = newPlayerName;
            UpdateStats();
        }

        /// <summary>
        /// Fired when the AI checkbox is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">optional parameters</param>
        private void OnAICheckboxChanged(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
