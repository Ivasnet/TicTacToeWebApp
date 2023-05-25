using TicTacToeGame.Models;

namespace TicTacToeGame.Core
{
	public class GameController
	{
		public Board GameBoard { get; private set; }
		public Player CrossPlayer { get; private set; }
		public Player ZeroPlayer { get; private set; }
		public Player CurrentPlayer { get; private set; }
		public WinnerType Winner { get; private set; }

		public GameController(Player crossPlayer, Player zeroPlayer)
		{
			CrossPlayer = crossPlayer;
			ZeroPlayer = zeroPlayer;
			GameBoard = new Board();
			CurrentPlayer = CrossPlayer;
		}

		public bool MakeMove(int row, int col)
		{
			if (GameBoard.CheckAndPlaceMark(row, col, CurrentPlayer.Mark))
			{
				Winner = GameBoard.CheckWin();
			}

			return false;
		}
	}
}