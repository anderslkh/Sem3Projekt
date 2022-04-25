namespace WebAPI.Models {
	public class TournamentDescription {
		public string GameName { get; set; }
		public int MinNoOfParticipant { get; set; }
		public int MaxNoOfParticipant { get; set; }
		public string TournamentDetails { get; set; }

		public TournamentDescription(string gameName, string tournamentDetails, int minNoOfParticipant, int maxNoOfParticipant)
		{
			GameName = gameName;
			TournamentDetails = tournamentDetails;
			MinNoOfParticipant = minNoOfParticipant;
			MaxNoOfParticipant = maxNoOfParticipant;
		}
	}
}
