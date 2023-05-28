using System.Numerics;
using TicTacToeGame.Models;
using TicTacToeWebApp.Data.Models;

namespace TicTacToeWebApp.Data.Abstractions
{
    public interface IDbAccess
    {
        Task AddGameAsync(Game game, string crossName, string zeroName, CancellationToken token = default);

		Task AddPlayerAsync(string name, CancellationToken token = default);

		Task AddPlayerAsync(Player player, CancellationToken token = default);

        Task AddPlayerWinnerTypeAsync(string playerName, WinnerType winnerType, CancellationToken token = default);

        Task<bool> IsPlayerExistsAsync(string userId, CancellationToken token = default);

        Task<IEnumerable<Game>> GetUserGamesAsync(Player player, CancellationToken token = default);

        Task<Player> GetPlayerAsync(string userId, CancellationToken token = default);

        Task<Game> GetGameByIdAsync(int id, CancellationToken token = default);

        Task<Game> GetGameByGuidAsync(string guid, CancellationToken token = default);

        Task<Player> GetPlayerByNameAsync(string name, CancellationToken token = default);
    }
}
