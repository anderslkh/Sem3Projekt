using DesktopConsumer.GUI.ContentPanels;
using DesktopConsumer.GUI.MenuPanels;

namespace DesktopConsumer.GUI
{
    public class UIFactory
    {

        public static Form CreateUserMenuUI()
        {
            return new UserMenu();
        }

        public static Form CreateTeamMenuUI()
        {
            //return new TeamMenu();
            return null;
        }

        public static Form CreateTournamentMenuUI()
        {
            //return new TournamentMenu();
            return new TournamentMenu();
        }

        public static Form TournamentListUI()
        {
            //return new TournamentListMenu();
            return null;
        }

        public static Form ReadAllUsersUI()
        {
            return new ReadUsersContentPanel();
        }
        public static Form CreateTournamentUI()
        {
            return new CreateTournamentContentPanel();
        }
        public static Form ReadTournamentsUI()
        {
            return new ReadTournamentsContentPanel();
        }
        public static Form ReadTournamentUI()
        {
            return new ReadTournamentContentPanel();
        }

        public static Form ReadUserUI()
        {
            return new ReadUserContentPanel();
        }

    }
}