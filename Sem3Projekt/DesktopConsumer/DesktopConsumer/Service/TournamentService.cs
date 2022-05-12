using DesktopComsumer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DesktopConsumer.Security;

public class TournamentService
{
    private readonly HttpClient _client;
    private readonly string _useJwt;
    private static readonly string restUrl = "https://localhost:7276/api/tournaments/";

    public TournamentService()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings.Get("JwtToken"));
    }

    public async Task<List<Tournament>> GetAllTournaments()
    {
        List<Tournament> foundTournaments = null;
        string useUrl = $"{restUrl}";
        var uri = new Uri(useUrl);
        try {
            
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                foundTournaments = JsonConvert.DeserializeObject<List<Tournament>>(content);
            } else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                CheckTokenValidity.VerifyTokenValidity(TokenState.Invalid);
                await GetAllTournaments();
            }
        }
        catch (Exception ex) {
            throw;
        }
        return foundTournaments;
    }

    public async Task<int> CreateTournament(Tournament tournament)
    {
        int result = -1;
        string useUrl = $"{restUrl}";
        var uri = new Uri(useUrl);
        try
        {
            var response = await _client.PostAsJsonAsync(uri, tournament);
            if (response.Content.ReadAsStringAsync().IsCompletedSuccessfully)
            {
                result = 1;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return result;
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
