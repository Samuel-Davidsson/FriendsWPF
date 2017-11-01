using Autofac;
using FriendOrganizer.UI.StartUp;
using System;
using System.Windows;

namespace FriendOrganizer.UI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new BootStrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected error occured. Please inform admin."
                + Environment.NewLine + e.Exception.Message, "Unexpected error.");
            e.Handled = true;
        }
    }
}
