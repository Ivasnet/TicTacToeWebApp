using TicTacToeGame.Models;

namespace TicTacToeGame.Core
{
	public class GameController
	{
		public Board GameBoard { get; private set; }
		public GamePlayer CrossPlayer { get; private set; }
		public GamePlayer ZeroPlayer { get; private set; }
		public GamePlayer CurrentPlayer { get; private set; }
		public WinnerType Winner { get; private set; }

		public GameController(GamePlayer crossPlayer, GamePlayer zeroPlayer)
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