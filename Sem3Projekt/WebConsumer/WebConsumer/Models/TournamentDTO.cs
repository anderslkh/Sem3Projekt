namespace WebConsumer.Models;

public class TournamentDTO {
	public int TournamentId { get; set; }
	public string TournamentName { get; set; }
	public DateTime TimeOfEvent { get; set; }
	public DateTime RegistrationDeadline { get; set; }
	public int MaxNoOfParticipants { get; set; }
	public int MinNoOfParticipants { get; set;}
	public int EnrolledParticipants { get; set; }


	public TournamentDTO(int _tournamentId, string _tournamentName, DateTime _timeOfEvent, DateTime _registrationDeadline, int _maxNoOfParticipants, int _minNoOfParticipants, int _enrolledParticipants) {
		TournamentId = _tournamentId;
		TournamentName = _tournamentName;
		TimeOfEvent = _timeOfEvent;
		RegistrationDeadline = _registrationDeadline;
		MaxNoOfParticipants = _maxNoOfParticipants;
		MinNoOfParticipants = _minNoOfParticipants;
		EnrolledParticipants = _enrolledParticipants;
	}
    public TournamentDTO()
    {

    }
}