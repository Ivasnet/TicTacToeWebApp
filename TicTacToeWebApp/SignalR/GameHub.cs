using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using TicTacToeWebApp.Controllers.Abstractions;

namespace TicTacToeWebApp.SignalR
{
    public class GameHub : Hub<ISignalRClient>
    {
        private readonly IGameController _gameController;

        public GameHub(IGameController controller)
        {
            _gameController = controller;
        }

        public async Task AddToGroup(string gameId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
        }

        public async Task TimerIsOver(string gameId)
        {
            await _gameController.TimerIsOverAsync(gameId);
        }

        public async Task Move(int row, int column, string gameId)
        {
            var currentState = await _gameController.MoveAsync(gameId, row, column);

            var serialized = JsonConvert.SerializeObject(currentState);

            await Clients.Group(gameId).ProcessCurrentBoard(serialized);
        }

        public async Task StartGame(string gameGuid, string crossId, string zeroId)
        {
            await _gameController.StartGameAsync(gameGuid, crossId, zeroId);
        }
    }

}
