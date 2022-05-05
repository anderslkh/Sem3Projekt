namespace WebAPI.Models {
	public class ParticipantsInTournament {
		public int TournamentId { get; set; }
		public List<string> ParticipantEmails { get; set; }
		public int MaxParticipants { get; set; }

		//public ParticipantsInTournament(int TournamentId, List<string> personEmails, int maxParticipants)
		//{
		//	TournamentId = TournamentId;
		//	ParticipantEmails = personEmails;
		//	MaxParticipants = maxParticipants;
		//}

		public ParticipantsInTournament()
		{
			ParticipantEmails = new List<string>();
		}
	}
}
