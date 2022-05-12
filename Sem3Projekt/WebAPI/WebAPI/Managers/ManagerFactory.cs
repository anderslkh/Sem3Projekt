using WebAPI.ModelDTOs;
using WebAPI.Models;

namespace WebAPI.Managers {
	public static class ManagerFactory {
		public static IManager<TournamentDTO, int> CreateTournamentManager()
		{
			return new TournamentManager();
		}

		public static IManager<Person, string> CreatePersonManager()
		{
			return new PersonManager();
		}
	}
}
