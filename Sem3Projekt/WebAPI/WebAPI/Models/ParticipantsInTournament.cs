namespace WebAPI.Models {
	public class ParticipantsInTournament {
		public int TournamentId { get; }
		public List<string> ParticipantEmails { get; }
		public int MaxParticipants { get; }

		public ParticipantsInTournament(int tournamentId, List<string> personEmails, int maxParticipants)
		{
			TournamentId = tournamentId;
			ParticipantEmails = personEmails;
			MaxParticipants = maxParticipants;
		}
	}
}
