using Newtonsoft.Json;
using WebComsumer.Models;

namespace WebConsumer.Service
{
    public class TournamentService
    {
        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/tournaments/";

        public TournamentService()
        {
            _client = new HttpClient();
        }
        public async Task<Tournament> GetTournamentById(int tournamentId)
        {
            Tournament foundTournament = null;
            string useUrl = $"{restUrl}{tournamentId}/";
            var uri = new Uri(useUrl);
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    foundTournament = JsonConvert.DeserializeObject<Tournament>(content);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return foundTournament;

        }
    }

}