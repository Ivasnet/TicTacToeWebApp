using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeWebApp.Data.Models
{
    [Table ("Players")]
    public class Player
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Scores { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
        [ForeignKey (nameof(AppUser))]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
