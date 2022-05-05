namespace WebAPI.ModelDTOs {
	public class EnrollmentDTO {
		public int TournamentId { get; set; }
		public int EnrolledParticipants { get; set; }
		public string PersonEmail { get; set; }

		public EnrollmentDTO(int tournamentId, int enrolledParticipants, string personEmail) {
			TournamentId = tournamentId;
			EnrolledParticipants = enrolledParticipants;
			PersonEmail = personEmail;
		}
	}
}
