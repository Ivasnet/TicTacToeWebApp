namespace TicTacToeGame.Models
{
	public class Board
	{
		public Cell[][] Cells { get; set; }
		public List<Move> Moves { get; set; }

		public bool IsBoardFull
		{
			get 
			{ 
				return Cells.All(cellsRow => cellsRow.All(cell => cell.Owner != MarkType.Free)); 
			}
		}

		public Board()
		{
			Cells = new Cell[3][];
			for (int i = 0; i < 3; i++)
			{
				Cells[i] = new Cell[3];
				for (int j = 0; j < 3; j++)
				{
					Cells[i][j] = new Cell();
				}
			}
			Moves = new List<Move>();
		}

		public bool CheckAndPlaceMark(int row, int col, MarkType mark)
		{
			if (Cells[row][col].Owner == MarkType.Free)
			{
				Cells[row][col].Owner = mark;
				Moves.Add(new()
				{
					Mark = mark,
					Row = row,
					Col = col
				}) ;
				return true;
			}
			return false;
		}

		public WinnerType CheckWin()
		{
			var winners = new List<WinnerType>
			{
				CheckRows(),
				CheckColumns(),
				CheckDiagonals()
			};

			var winner = winners.FirstOrDefault(winner => winner != WinnerType.None);

			if (winner != WinnerType.None)
			{
				return winner;
			}

			if (IsBoardFull) return WinnerType.Draw;

			return winner;
		}

		public bool IsNowTurnCross()
		{
			int crosses = 0, zeros = 0;
			for (int i = 0; i < 3; i++)
			{
                for (int j = 0; j < 3; j++)
                {
					if (Cells[i][j].Owner != MarkType.Free)
					{
						if (Cells[i][j].Owner != MarkType.Cross)
							crosses++;
						else zeros++;

                    }
                }
            }
            return crosses == zeros;
		}

		private WinnerType CheckRows()
		{
			for (int i = 0; i < 3; i++)
			{
				if (Cells[i][0].Owner == Cells[i][1].Owner 
					&& Cells[i][1].Owner == Cells[i][2].Owner 
					&& Cells[i][0].Owner != MarkType.Free)
				{
					return GetWinner(Cells[i][0].Owner);
				}
			}

			return WinnerType.None;
		}

		private WinnerType CheckColumns()
		{
			for (int i = 0; i < 3; i++)
			{
				if (Cells[0][i].Owner == Cells[1][i].Owner
					&& Cells[1][i].Owner == Cells[2][i].Owner 
					&& Cells[0][i].Owner != MarkType.Free)
				{
					return GetWinner(Cells[0][i].Owner);
				}
			}

			return WinnerType.None;
		}

		private WinnerType CheckDiagonals()
		{
			if (Cells[0][0].Owner == Cells[1][1].Owner 
				&& Cells[1][1].Owner == Cells[2][2].Owner 
				&& Cells[0][0].Owner != MarkType.Free)
			{
				return GetWinner(Cells[0][0].Owner);
			}

			if (Cells[0][2].Owner == Cells[1][1].Owner 
				&& Cells[1][1].Owner == Cells[2][0].Owner 
				&& Cells[0][2].Owner != MarkType.Free)
			{
				return GetWinner(Cells[0][2].Owner);
			}

			return WinnerType.None;
		}

		private static WinnerType GetWinner(MarkType mark)
		{
			if (mark == MarkType.Zero) 
				return WinnerType.ZeroPlayer;

			else if (mark == MarkType.Cross) 
				return WinnerType.CrossPlayer;

			return WinnerType.None;
		}
	}
}