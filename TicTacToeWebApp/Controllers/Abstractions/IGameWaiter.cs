using TicTacToeWebApp.Data.Models;

namespace TicTacToeWebApp.Controllers.Abstractions
{
    public interface IGameWaiter
    {
        Task<(Game Game, bool First)> WaitGameAsync(Player player, CancellationToken token);
    }
}
