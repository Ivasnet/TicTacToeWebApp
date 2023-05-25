namespace TicTacToeGame.Models
{
	public class Cell
	{
		public MarkType Owner { get; set; }

		public Cell()
		{
			Owner = MarkType.Free;
		}
	}
}
