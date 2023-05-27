using Microsoft.AspNetCore.Identity;

namespace TicTacToeWebApp.Data.Models
{
    public class AppUser : IdentityUser
    {
        public Player Player { get; set; }
    }
}
