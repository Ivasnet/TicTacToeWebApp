using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TicTacToeGame.Models;
using TicTacToeWebApp.Data.Abstractions;
using TicTacToeWebApp.Data.Models;

namespace TicTacToeWebApp.Data.Controllers
{
    public class DbAccess : IDbAccess
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public DbAccess(IDbContextFactory<AppDbContext> context)
        {
            _contextFactory = context ?? throw new ArgumentNullException(nameof(context));
        }

		public async Task AddGameAsync(Game game, string crossName, string zeroName, CancellationToken token = default)
		{
			ArgumentNullException.ThrowIfNull(game);
			ArgumentNullException.ThrowIfNull(crossName);
			ArgumentNullException.ThrowIfNull(zeroName);

			try
			{
				using var context = await _contextFactory.CreateDbContextAsync(token).ConfigureAwait(false);

				var crossPlayer = await context.Players
					.FirstAsync(x => x.Name == crossName, token)
					.ConfigureAwait(false);

				var zeroPlayer = await context.Players
					.FirstAsync(x => x.Name == zeroName, token)
					.ConfigureAwait(false);

				game.CrossPlayer = crossPlayer;
				game.ZeroPlayer = zeroPlayer;

				context.Games.Add(game);
				await context.SaveChangesAsync(token).ConfigureAwait(false);

			}
			catch 
			{ 
				//TODO Logging
			}
		}

		public async Task AddPlayerAsync(string name, CancellationToken token = default)
		{
			ArgumentNullException.ThrowIfNull(name);
			try
			{
				using var context = await _contextFactory.CreateDbContextAsync(token).ConfigureAwait(false);
				context.Players.Add(new Player
				{
					Name = name,
					UserId = context.Users.First(u => u.UserName == name).Id
				});
				await context.SaveChangesAsync(token).ConfigureAwait(false);
			}
			catch
			{
				//TODO Logging
			}
		}

		public async Task<IEnumerable<Game>> GetUserGamesAsync(Player player, CancellationToken token = default)
		{
			try
			{
				using var context = await _contextFactory.CreateDbContextAsync(token).ConfigureAwait(false);

				return await context.Games
					.Include(x => x.ZeroPlayer)
					.Include(x => x.CrossPlayer)
					.Where(x => x.CrossPlayer.Id == player.Id || x.ZeroPlayer.Id == player.Id)
					.ToArrayAsync(token)
					.ConfigureAwait(false);
			}
			catch
			{
				//TODO Logging
				throw;
			}
		}

		public async Task<Player> GetPlayerAsync(string userId, CancellationToken token = default)
		{
			try
			{
				using var context = await _contextFactory.CreateDbContextAsync(token).ConfigureAwait(false);
				return await context.Players.FirstAsync(x => x.UserId == userId, token).ConfigureAwait(false);
			}
			catch
			{
				//TODO Logging
				throw;
			}
		}

		public async Task<bool> IsPlayerExistsAsync(string name, CancellationToken token = default)
		{
			try
			{
				using var context = await _contextFactory.CreateDbContextAsync(token).ConfigureAwait(false);
				return await context.Players.AnyAsync(x => x.Name == name, token).ConfigureAwait(false);
			}
			catch
			{
				//TODO Logging
				throw;
			}
		}

		public async Task<Game> GetGameAsync(int id, CancellationToken token = default)
		{
			try
			{
				using var context = await _contextFactory.CreateDbContextAsync(token).ConfigureAwait(false);
				return await context.Games.FirstAsync(x => x.Id == id, token).ConfigureAwait(false);
			}
			catch
			{
				//TODO Logging
				throw;
			}
		}

		public async Task<Player> GetPlayerByNameAsync(string name, CancellationToken token = default)
		{
			try
			{
				using var context = await _contextFactory.CreateDbContextAsync(token).ConfigureAwait(false);
				var user = await context.Users.FirstAsync(x => x.UserName == name, token).ConfigureAwait(false);
				var player = await context.Players.FirstAsync(p => p.UserId == user.Id, token).ConfigureAwait(false);
				return player;
			}
			catch
			{
				//TODO Logging
				throw;
			}
		}
	}
}
