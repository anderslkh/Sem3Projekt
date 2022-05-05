namespace WebConsumer.Models {
	public class EnrollmentDTO
	{
		public int TournamentId { get; set; }
		public int EnrolledParticipants { get; set; }
		public string PersonEmail { get; set; }

		public EnrollmentDTO()
		{
		}
		public EnrollmentDTO(int tournamentId, int enrolledParticipants, string personEmail)
		{
			this.TournamentId = tournamentId;
			this.EnrolledParticipants = enrolledParticipants;
			this.PersonEmail = personEmail;
		}
	}
}
