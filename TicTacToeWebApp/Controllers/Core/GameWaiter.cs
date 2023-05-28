using TicTacToeWebApp.Controllers.Abstractions;
using TicTacToeWebApp.Data.Models;

namespace TicTacToeWebApp.Controllers.Core
{
    internal sealed class GameWaiter : IGameWaiter
    {
        private Player? _firstPlayer;
        private TaskCompletionSource<(Game Game, bool First)> _gameCompletionSource;
        public GameWaiter()
        {
            _gameCompletionSource = new TaskCompletionSource<(Game Game, bool First)>();   
        }

        public Task<(Game Game, bool First)> WaitGameAsync(Player player, CancellationToken token)
        {
            try
            {
                if(_firstPlayer is null)
                {
                    _firstPlayer = player;
                    _gameCompletionSource = new();
                } 
                else
                {
                    var game = new Game()
                    {
                        CrossPlayer = _firstPlayer,
                        ZeroPlayer = player,
                        Date = DateTime.Now,
                        Moves = new List<Move>(),
                        Guid = Guid.NewGuid().ToString(),
                        WinnerType = TicTacToeGame.Models.WinnerType.None
                    };

                    _firstPlayer = null;

                    _gameCompletionSource.SetResult((game, true));
                    return Task.FromResult((game, false));
                }

                return _gameCompletionSource.Task;
            }
            catch(Exception ex)
            {
                // TODO!!!!!!

                throw;
            }
        }
    }
}
