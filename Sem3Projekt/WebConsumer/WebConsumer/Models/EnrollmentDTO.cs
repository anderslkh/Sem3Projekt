namespace WebConsumer.Models {
	public class EnrollmentDTO
	{
		public int TournamentId { get; set; }
		public int EnrolledParticipants { get; set; }
		public string PersonEmail { get; set; }

		public int MaxNoOfParticipants { get; set; }

		public EnrollmentDTO()
		{
		}
		public EnrollmentDTO(int tournamentId, int enrolledParticipants, string personEmail, int maxNoOfParticipants)
		{
			TournamentId = tournamentId;
			EnrolledParticipants = enrolledParticipants;
			PersonEmail = personEmail;
			MaxNoOfParticipants = maxNoOfParticipants;
		}
	}
}
