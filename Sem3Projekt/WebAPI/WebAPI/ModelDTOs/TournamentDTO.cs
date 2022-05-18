namespace WebAPI.ModelDTOs {
	public class TournamentDTO {
		public int TournamentId { get; set; }
		public string TournamentName { get; set; }
		public DateTime TimeOfEvent { get; set; }
		public DateTime RegistrationDeadline { get; set; }
		public int MaxParticipants { get; set; }
		public int MinParticipants { get; set; }

		public int EnrolledParticipants { get; set; }


        public TournamentDTO()
        {
        }

        // Constructor for creating a new tournament in database
        public TournamentDTO(string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int maxParticipants, int minParticipants) {
            TournamentName = tournamentName;
            TimeOfEvent = timeOfEvent;
            RegistrationDeadline = registrationDeadline;
            MaxParticipants = maxParticipants;
            MinParticipants = minParticipants;
            EnrolledParticipants = 0;
        }

		// Constructor for reading tournament with enrolled participants
        public TournamentDTO(int tournamentId, string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int maxParticipants, int minParticipants, int enrolledParticipants)
		{
			TournamentId = tournamentId;
			TournamentName = tournamentName;
			TimeOfEvent = timeOfEvent;
			RegistrationDeadline = registrationDeadline;
			MaxParticipants = maxParticipants;
			MinParticipants = minParticipants;
			EnrolledParticipants = enrolledParticipants;
		}
	}
}
