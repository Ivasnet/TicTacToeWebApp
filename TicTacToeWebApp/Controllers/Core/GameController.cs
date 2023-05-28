using System.Collections.Concurrent;
using TicTacToeGame.Core;
using TicTacToeGame.Models;
using TicTacToeWebApp.Controllers.Abstractions;
using TicTacToeWebApp.Data.Abstractions;

namespace TicTacToeWebApp.Controllers.Core
{
    public class GameController : IGameController
    {
        private readonly ConcurrentDictionary<string, RulesController> _activeGames = new();

        public Task<Board> MoveAsync(string gameId, int row, int column, CancellationToken token = default)
        {
            try
            {
                if(_activeGames.TryGetValue(gameId, out var controller))
                {
                    controller.CheckAndPlaceMark(row, column);

					if (controller.Winner != WinnerType.None)
                    { 
                        _activeGames.TryRemove(gameId, out _);
                    }
                    return Task.FromResult(controller.GameBoard);
                }

                throw new Exception();
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public async Task StartGameAsync(string gameGuid, string crossId, string zeroId, CancellationToken token = default)
        {
            try
            {
                if (_activeGames.ContainsKey(gameGuid))
                {
                    return;
                }

                var currentController = new RulesController(new GamePlayer(crossId, MarkType.Cross), new GamePlayer(zeroId, MarkType.Zero));

                _activeGames.TryAdd(gameGuid, currentController);
            }
            catch
            {
                throw;
            }
        }

        public async Task TimerIsOverAsync(string gameGuid)
        {
            try
            {
                if (_activeGames.ContainsKey(gameGuid))
                {
                    _activeGames.TryRemove(gameGuid, out _);
                }

                throw new Exception();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
