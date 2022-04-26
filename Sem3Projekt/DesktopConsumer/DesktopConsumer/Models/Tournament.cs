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
		public int MinParticipants { get; set; }
		public int MaxParticipants { get; set; }

		public Tournament(int tournamentId, string tournamentName, DateTime timeOfEvent, DateTime registrationDeadline, int minParticipants, int maxParticipants)
		{
			TournamentId = tournamentId;
			TournamentName = tournamentName;
			TimeOfEvent = timeOfEvent;
			RegistrationDeadline = registrationDeadline;
			MinParticipants = minParticipants;
			MaxParticipants = maxParticipants;
		}
	}
}

