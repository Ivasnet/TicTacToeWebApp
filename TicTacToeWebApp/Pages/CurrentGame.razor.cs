using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Linq;
using TicTacToeGame.Models;
using TicTacToeWebApp.Data.Models;

namespace TicTacToeWebApp.Pages
{
    public partial class CurrentGame
    {
        [Parameter]
        public string GameGuid { get; set; }
        public string Text { get; set; } = "Empty";
        public bool IsMoveMaked { get; set; } = false;
        public string TimerText { get; set; }
        public int PlayersTimer { get; set; } = 15;
        public MarkType CurrentMarkType { get; set; }

        Board CurrentBoard;

        HubConnection hubConnection;

        System.Timers.Timer Timer;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();

            var user = authState.User;

            CurrentBoard = new Board();

            if (user.Identity.IsAuthenticated)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        CurrentBoard.Cells[i][j] = new Cell();
                    }
                }

                var currentGame = await DataBase.GetGameByGuidAsync(GameGuid).ConfigureAwait(false);
                CurrentMarkType = currentGame.CrossPlayer.Name == user.Identity.Name ? MarkType.Cross : MarkType.Zero;

                SetTimer("Ваш ход!");

                if (CurrentMarkType == MarkType.Zero)
                {
                    IsMoveMaked = true;
                    TimerText = "Ход вашего противника!";
                }
                else
                {
                    TimerText = "Ваш ход!";
                }

                hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/gameHub")).Build();
                hubConnection.On<string>("ProcessCurrentBoard", (serializedBoard) =>
                {

                    var deserialized = JsonConvert.DeserializeObject<Board>(serializedBoard);
                    if (deserialized.CheckWin() != WinnerType.None)
                    {
						if (CurrentMarkType != MarkType.Zero)
                        {
							List<Data.Models.Move> moves = new();
							var game = DataBase.GetGameByGuidAsync(GameGuid).Result;
							game.WinnerType = deserialized.CheckWin();
							foreach (var move in deserialized.Moves)
							{
								moves.Add(new Data.Models.Move()
								{
									Id = move.Id,
									Mark = move.Mark,
									Row = move.Row,
									Col = move.Col
								});
							}
							game.Moves = moves;
							DataBase.AddGameAsync(game, game.CrossPlayer.Name, game.ZeroPlayer.Name);
						}
						var player = DataBase.GetPlayerByNameAsync(user.Identity.Name).Result;
						var totalGames = DataBase.GetUserGamesAsync(player).Result;
                        var totalWins = totalGames.Select(g => 
                        g.ZeroPlayer.Name == player.Name 
                        && g.WinnerType == WinnerType.ZeroPlayer
                        || g.CrossPlayer.Name == player.Name
						&& g.WinnerType == WinnerType.CrossPlayer).Count();
                        var totalDraws = totalGames.Select(g => g.WinnerType == WinnerType.Draw).Count();
                        player.Games = totalGames.Count();
						player.Wins = totalWins;
						player.Draws = totalDraws;
						player.Loses = player.Games - player.Wins - player.Draws;
                        player.Scores = player.Wins * 2 + player.Draws;
                        DataBase.AddPlayerAsync(player);

						NavigationManager.NavigateTo("/playerprofile");
                    }
                    CurrentBoard = deserialized;
                    PlayersTimer = 15;
                    StateHasChanged();
                    if ((deserialized.IsNowTurnCross() && CurrentMarkType == MarkType.Cross)
                    || (!deserialized.IsNowTurnCross() && CurrentMarkType == MarkType.Zero))
                    {
                        TimerText = "Ваш ход!";
                        
                        IsMoveMaked = false;
                    }
                    else
                    {
                        TimerText = "Ход вашего противника!";
                    }
                });
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("AddToGroup", GameGuid);
                await hubConnection.SendAsync("StartGame", GameGuid, currentGame.CrossPlayer.Name, currentGame.ZeroPlayer.Name);
            }
        }

        string GetMarkSymbol(MarkType mark)
        {
            return mark switch
            {
                MarkType.Zero => "Нолик",
                MarkType.Cross => "Крестик",
                _ => "Пусто",
            };
        }

        void MakeMove(int cellIndex)
        {
            if (!IsMoveMaked)
            {
                IsMoveMaked = true;
                hubConnection.SendAsync("Move", cellIndex / 3, cellIndex % 3, GameGuid).GetAwaiter().GetResult();                
            }
        }

        void SetTimer(string timerPlayerName)
        {
            TimerText = timerPlayerName;
            PlayersTimer = 15;
            Timer = new System.Timers.Timer
            {
                Interval = 1000
            };

            Timer.Elapsed += (sender, args) =>
            {
                PlayersTimer--;
                if (PlayersTimer == 0)
                {
                    TimerIsOver();
                    NavigationManager.NavigateTo("/playerprofile");
                }
                InvokeAsync(StateHasChanged);
            };

            Timer.Start();
        }

        void TimerIsOver()
        {
            hubConnection.SendAsync("TimerIsOver", GameGuid).GetAwaiter().GetResult();
        }
    }
}