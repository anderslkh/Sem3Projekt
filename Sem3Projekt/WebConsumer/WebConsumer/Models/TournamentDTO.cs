namespace WebConsumer.Models;

public class TournamentDTO {
	public int TournamentId;
	public string TournamentName;
	public DateTime TimeOfEvent;
	public DateTime RegistrationDeadline;
	public int MaxNoOfParticipants;
	public int MinNoOfParticipants;
	public int EnrolledParticipants;

	public TournamentDTO(int _tournamentId, string _tournamentName, DateTime _timeOfEvent, DateTime _registrationDeadline, int _maxNoOfParticipants, int _minNoOfParticipants, int _enrolledParticipants) {
		TournamentId = _tournamentId;
		TournamentName = _tournamentName;
		TimeOfEvent = _timeOfEvent;
		RegistrationDeadline = _registrationDeadline;
		MaxNoOfParticipants = _maxNoOfParticipants;
		MinNoOfParticipants = _minNoOfParticipants;
		EnrolledParticipants = _enrolledParticipants;
	}
}