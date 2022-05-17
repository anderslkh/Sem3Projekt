using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopComsumer.Models
{

	public class Tournament
	{
		public int TournamentId { get; set; }
		public string TournamentName { get; set; }
		public DateTime TimeOfEvent { get; set; }
		public DateTime RegistrationDeadline { get; set; }
		public int MinParticipants { get; set; }
		public int MaxParticipants { get; set; }
		public int EnrolledParticipants { get; set; }

        public Tournament()
        {

        }
		public Tournament(int tournamentId, string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int minParticipants, int maxParticipants)
		{
			TournamentId = tournamentId;
			TournamentName = tournamentName;
			TimeOfEvent = timeOfEvent;
			RegistrationDeadline = registrationDeadline;
			MinParticipants = minParticipants;
			MaxParticipants = maxParticipants;
		}

        public Tournament(string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int minParticipants, int maxParticipants) {
            TournamentName = tournamentName;
            TimeOfEvent = timeOfEvent;
            RegistrationDeadline = registrationDeadline;
            MinParticipants = minParticipants;
            MaxParticipants = maxParticipants;
        }

		public override string ToString()
        {
            return $"Navn: {TournamentName} | Minimum deltagere: {MinParticipants} | Maximum deltagere: {MaxParticipants} | Tilmeldte: {EnrolledParticipants}";
        }
    }
}

