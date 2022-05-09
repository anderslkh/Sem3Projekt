namespace WebAPI.Model_DTO_s {
	public class TournamentDTO {
		public int TournamentId { get; set; }
		public string TournamentName { get; set; }
		public DateTime TimeOfEvent { get; set; }
		public DateTime RegistrationDeadline { get; set; }
		public int MaxNoOfParticipants { get; set; }
		public int MinNoOfParticipants { get; set; }

		public int EnrolledParticipants { get; set; }


        public TournamentDTO()
        {
        }

        // Constructor for creating a new tournament in database
        public TournamentDTO(string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int maxParticipants, int minParticipants) {
            TournamentName = tournamentName;
            TimeOfEvent = timeOfEvent;
            RegistrationDeadline = registrationDeadline;
            MaxNoOfParticipants = maxParticipants;
            MinNoOfParticipants = minParticipants;
        }

		// Constructor for reading tournament with enrolled participants
        public TournamentDTO(int tournamentId, string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int maxNoOfParticipants, int minNoOfParticipants, int enrolledParticipants)
		{
			TournamentId = tournamentId;
			TournamentName = tournamentName;
			TimeOfEvent = timeOfEvent;
			RegistrationDeadline = registrationDeadline;
			MaxNoOfParticipants = maxNoOfParticipants;
			MinNoOfParticipants = minNoOfParticipants;
			EnrolledParticipants = enrolledParticipants;
		}
	}
}
