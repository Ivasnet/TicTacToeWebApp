using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeWebApp.Data.Models
{
    [Table ("Players")]
    public class Player
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Scores { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
    }
}
