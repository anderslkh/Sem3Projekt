using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopComsumer.Models
{

	public class Tournament
	{
		public int TournamentId { get; }
		public string TournamentName { get; set; }
		public DateTime TimeOfEvent { get; set; }
		public DateTime RegistrationDeadline { get; set; }
		public int MinNoOfParticipants { get; set; }
		public int MaxNoOfParticipants { get; set; }
		public int EnrolledParticipants { get; set; }

        public Tournament()
        {

        }
		public Tournament(int tournamentId, string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int minNoOfParticipants, int maxNoOfParticipants)
		{
			TournamentId = tournamentId;
			TournamentName = tournamentName;
			TimeOfEvent = timeOfEvent;
			RegistrationDeadline = registrationDeadline;
			MinNoOfParticipants = minNoOfParticipants;
			MaxNoOfParticipants = maxNoOfParticipants;
		}

        public Tournament(string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int minNoOfParticipants, int maxNoOfParticipants) {
            TournamentName = tournamentName;
            TimeOfEvent = timeOfEvent;
            RegistrationDeadline = registrationDeadline;
            MinNoOfParticipants = minNoOfParticipants;
            MaxNoOfParticipants = maxNoOfParticipants;
        }

		public override string ToString()
        {
            return $"Navn: {TournamentName} | Minimum deltagere: {MinNoOfParticipants} | Maximum deltagere: {MaxNoOfParticipants} | Tilmeldte: {EnrolledParticipants}";
        }
    }
}

