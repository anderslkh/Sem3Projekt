namespace WebAPI.Models
{
	public class Tournament
	{
		public int TournamentId { get; }
		public string TournamentName { get; set; }
		public DateTime TimeOfEvent { get; set; }
		public DateTime RegistrationDeadline { get; set; }
		public int MinNoOfParticipant { get; set; }
		public int MaxNoOfParticipant { get; set; }
		//public TournamentDescription TournamentDescription { get; set; }
		public List<Person> ListOfParticipants { get; set; }

		public Tournament(int tournamentId, string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int minNoOfParticipant, int maxNoOfParticipant)
		{
			TournamentId = tournamentId;
			TournamentName = tournamentName;
			TimeOfEvent = timeOfEvent;
			RegistrationDeadline = registrationDeadline;
			MinNoOfParticipant = minNoOfParticipant;
			MaxNoOfParticipant = maxNoOfParticipant;
			ListOfParticipants = new List<Person>();
		}
	}

}
