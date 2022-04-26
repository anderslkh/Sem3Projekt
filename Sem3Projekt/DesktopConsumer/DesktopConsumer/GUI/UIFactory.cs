using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopConsumer.GUI.ContentPanels;
using DesktopConsumer.GUI.MenuPanels;
using GUI;

namespace GUI
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

        public static Form UserContentSearch()
        {
            return new UsersContentPanel();
        }

    }
}