namespace TicTacToe
{
    /// <summary>
    /// Basic abstraction of a playing entity.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Symbol used to identify the player
        /// </summary>
        char Symbol { get; }
    }
}
