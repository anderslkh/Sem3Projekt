using System.Net.Http.Headers;
using WebConsumer.Models;

namespace WebConsumer.Service
{
    public class EnrollmentService
    {


        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/tournaments/";

        public EnrollmentService()
        {
            _client = new HttpClient();
        }
        public EnrollmentService(string? token)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<int> EnrollInTournament(EnrollmentDTO enrollmentDto)
        {
            int result = -1;
            string useUrl = $"{restUrl}enrollment/{enrollmentDto.TournamentId}";
            var uri = new Uri(useUrl);
            try
            {

                var response = await _client.PutAsJsonAsync(uri, enrollmentDto);
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
