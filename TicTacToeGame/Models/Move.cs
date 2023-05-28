namespace TicTacToeGame.Models
{
	public class Move
	{
		public int Id { get; set; }
		public MarkType Mark { get; set; }
		public int Row { get; set; }
		public int Col { get; set; }
	}
}
