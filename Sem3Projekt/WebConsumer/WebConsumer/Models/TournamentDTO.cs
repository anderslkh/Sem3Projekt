namespace WebConsumer.Models;

public class TournamentDTO {
	public int TournamentId;
	public string TournamentName;
	public DateTime TimeOfEvent;
	public DateTime RegistrationDeadline;
	public int MaxParticipants;
	public int MinParticipants;
	public int EnrolledParticipants;

	public TournamentDTO(int _tournamentId, string _tournamentName, DateTime _timeOfEvent, DateTime _registrationDeadline, int maxParticipants, int minParticipants, int _enrolledParticipants) {
		TournamentId = _tournamentId;
		TournamentName = _tournamentName;
		TimeOfEvent = _timeOfEvent;
		RegistrationDeadline = _registrationDeadline;
		MaxParticipants = maxParticipants;
		MinParticipants = minParticipants;
		EnrolledParticipants = _enrolledParticipants;
	}
}