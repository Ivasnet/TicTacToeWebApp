using TicTacToeGame.Models;

namespace TicTacToeGame.Core
{
	public class RulesController
	{
		public Board GameBoard { get; set; }
		public GamePlayer CrossPlayer { get; set; }
		public GamePlayer ZeroPlayer { get; set; }
		public GamePlayer CurrentPlayer { get; set; }
		public WinnerType Winner { get; set; }

		public RulesController(GamePlayer crossPlayer, GamePlayer zeroPlayer)
		{
			CrossPlayer = crossPlayer;
			ZeroPlayer = zeroPlayer;
			GameBoard = new Board();
			CurrentPlayer = CrossPlayer;
		}

		public bool CheckAndPlaceMark(int row, int col)
		{
			var isCorrect = GameBoard.CheckAndPlaceMark(row, col, CurrentPlayer.Mark);
			if (isCorrect) 
			{
                ChangePlayerTurn();
				Winner = GameBoard.CheckWin();
            }
            
			return isCorrect;
		}

		public bool IsMyTurn(GamePlayer player) => CurrentPlayer == player;

		public void ChangePlayerTurn()
		{
			if (CurrentPlayer == CrossPlayer) CurrentPlayer = ZeroPlayer;
			else CurrentPlayer = CrossPlayer;
		}
	}
}