using WebComsumer.Models;
using WebConsumer.Models;

namespace WebConsumer.Service {
	public static class ServiceFactory {

		public static IService<TournamentDTO, int> CreateTournamentService()
		{
			return new TournamentService();
		}


		public static IService<Person, string> CreatePersonService()
		{
			return new PersonService();
		}
	}
}
