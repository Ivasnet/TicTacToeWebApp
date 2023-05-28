using TicTacToeGame.Models;

namespace TicTacToeWebApp.Controllers.Abstractions
{
    public interface IGameController
	{
        Task StartGameAsync(string gameGuid, string crossId, string zeroId, CancellationToken token = default);
		Task<Board> MoveAsync(string gameId, int row, int column, CancellationToken token = default);
        Task TimerIsOverAsync(string gameGuid);
    }
}
