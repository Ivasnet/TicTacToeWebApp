using TicTacToeWebApp.Data.Abstractions;
using TicTacToeWebApp.Data.Controllers;

namespace TicTacToeWebApp.Data
{
	public static class AppDbDIExtensions
	{
		public static IServiceCollection AddDbServices(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddScoped<IDbAccess, DbAccess>();

			return serviceDescriptors;
		}
	}
}
