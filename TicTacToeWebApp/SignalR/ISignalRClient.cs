using TicTacToeGame.Models;

namespace TicTacToeWebApp.SignalR
{
    public interface ISignalRClient
    {
        Task ProcessCurrentBoard(string serializedBoard);
    }
}
