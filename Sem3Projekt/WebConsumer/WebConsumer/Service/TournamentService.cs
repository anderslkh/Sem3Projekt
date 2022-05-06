using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using WebComsumer.Models;
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
        public async Task<TournamentDTO> GetItem(int tournamentId)
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
            try {
              var response = await _client.GetAsync(uri);
              if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                foundTournaments = JsonConvert.DeserializeObject<List<TournamentDTO>>(content);
              }
            } catch (Exception e)
            {
                throw;
            }
            return foundTournaments;
        }

        public async Task<int> EnrollInTournament(EnrollmentDTO enrollmentDto)
        {
	        int result = -1;
	        string useUrl = $"{restUrl}enroll/{enrollmentDto.TournamentId}";
            var uri = new Uri(useUrl);
            try
            {
	            
                var response = await _client.PostAsJsonAsync(uri, enrollmentDto);
                result = Int32.Parse(response.Content.ReadAsStringAsync().Result);

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }

}