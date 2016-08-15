namespace TicTacToe
{
    /// <summary>
    /// A class representing the player.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Symbol of the player
        /// </summary>
        public char Symbol { get; private set; }

        /// <summary>
        /// Current name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Current Score
        /// </summary>
        public int Score { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="symbol">player`s symbol</param>
        /// <param name="name">player`s name</param>
        public Player(char symbol, string name)
        {
            Symbol = symbol;
            Name = name;
            Score = 0;
        }
    }
}
