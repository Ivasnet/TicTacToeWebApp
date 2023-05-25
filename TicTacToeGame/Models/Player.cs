namespace TicTacToeGame.Models
{
	public class Player
	{
		public string Name { get; private set; }

		public MarkType Mark { get; private set; }

        public Player(string name, MarkType marker)
        {
            Name = name;
            Mark = marker;
        }
    }
}
