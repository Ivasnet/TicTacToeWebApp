using TicTacToeGame.Models;

namespace TicTacToeWebApp.Data.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CrossPlayer { get; set; }
        public string ZeroPlayer { get; set; }
        public List<Move>? Moves { get; set; }
        public WinnerType WinnerType { get; set; }
    }
}
