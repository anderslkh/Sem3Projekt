using DesktopConsumer.Controller;
using DesktopConsumer.GUI;
using DesktopConsumer.Security;

namespace DesktopConsumer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //CheckTokenValidity.VerifyTokenValidity(TokenState.Invalid);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());

        }
        
    }
}