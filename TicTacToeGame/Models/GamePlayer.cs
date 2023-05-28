namespace TicTacToeGame.Models
{
	public class GamePlayer
	{
		public string Name { get; private set; }

        public Timer MoveTime { get; set; }

		public MarkType Mark { get; private set; }

        public GamePlayer(string name, MarkType marker)
        {
            Name = name;
            Mark = marker;
        }
    }
}
