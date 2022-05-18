namespace WebAPI.ModelDTOs {
	public class EnrollmentDTO {
		public int TournamentId { get; set; }
		public int EnrolledParticipants { get; set; }
		public string PersonEmail { get; set; }
		public int MaxParticipants { get; set; }

        public EnrollmentDTO()
        {
        }
		public EnrollmentDTO(int tournamentId, int enrolledParticipants, string personEmail, int maxParticipants) {
			TournamentId = tournamentId;
			EnrolledParticipants = enrolledParticipants;
			PersonEmail = personEmail;
			MaxParticipants = maxParticipants;
		}
	}
}
