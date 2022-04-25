using WebAPI.Models;

namespace WebAPI.Managers {
	public static class ManagerFactory {
		public static IManager<Tournament, int> CreateTournamentManager()
		{
			return new TournamentManager();
		}

		public static IManager<Person, string> CreatePersonManager()
		{
			return new PersonManager();
		}
	}
}
