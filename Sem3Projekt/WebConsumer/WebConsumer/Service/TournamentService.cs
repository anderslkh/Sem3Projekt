using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using WebConsumer.Models;

namespace WebConsumer.Service
{
    public class TournamentService : IService<TournamentDTO, int>
    {
        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/tournaments/";

        public TournamentService()
        {
            _client = new HttpClient();
        }
        public TournamentService(string? token)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<TournamentDTO> GetItemById(int tournamentId)
        {
            TournamentDTO foundTournament = null;
            string useUrl = $"{restUrl}{tournamentId}/";
            var uri = new Uri(useUrl);
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
	                var content = await response.Content.ReadAsStringAsync();
                    foundTournament = JsonConvert.DeserializeObject<TournamentDTO>(content);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return foundTournament;

        }

        public async Task<List<TournamentDTO>> GetAllItems()
        {
            List<TournamentDTO> foundTournaments = null;
            string useUrl = $"{restUrl}";
            var uri = new Uri(useUrl);
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    foundTournaments = JsonConvert.DeserializeObject<List<TournamentDTO>>(content);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return foundTournaments;
        }

        public async Task<TournamentDTO> UpdateTournament(int tournamentId)
        {
            //implement update method for tournament
            return null;
        }
        public async Task<bool> DeleteTournament(int tournamentId)
        {

            bool result = false;
            string useUrl = $"{restUrl}{tournamentId}/";
            var uri = new Uri((useUrl));
            try
            {
                var response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }
    }

}