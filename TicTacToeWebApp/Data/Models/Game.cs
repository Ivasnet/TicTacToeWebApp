using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicTacToeGame.Models;

namespace TicTacToeWebApp.Data.Models
{
    [Table ("Games")]
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; set; }
        public DateTime? Date { get; set; }
        public Player? CrossPlayer { get; set; }
        public Player? ZeroPlayer { get; set; }
        public List<Move>? Moves { get; set; }
        public WinnerType WinnerType { get; set; }
    }
}
