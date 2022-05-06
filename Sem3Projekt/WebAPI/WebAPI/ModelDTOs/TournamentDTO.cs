namespace WebAPI.Model_DTO_s {
	public class TournamentDTO {
		public readonly int _tournamentId;
		public readonly string _tournamentName;
		public readonly DateTime _timeOfEvent;
		public readonly DateTime _registrationDeadline;
		public readonly int _maxNoOfParticipants;
		public readonly int _minNoOfParticipants;
		public readonly int _enrolledParticipants;

		public TournamentDTO(int tournamentId, string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int maxNoOfParticipants, int minNoOfParticipants, int enrolledParticipants)
		{
			_tournamentId = tournamentId;
			_tournamentName = tournamentName;
			_timeOfEvent = timeOfEvent;
			_registrationDeadline = registrationDeadline;
			_maxNoOfParticipants = maxNoOfParticipants;
			_minNoOfParticipants = minNoOfParticipants;
			_enrolledParticipants = enrolledParticipants;
		}
	}
}
