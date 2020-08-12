using Reunion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReunionSampleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Our app's "identity" is registered through the Package.appxmanifest

            ReunionApp.OnActivated += ReunionApp_OnActivated;
            ReunionApp.OnBackgroundActivated += ReunionApp_OnBackgroundActivated;
        }

        private void ReunionApp_OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs args)
        {
            Dispatcher.Invoke(delegate
            {
                // Only difference here is calling the Compat API so that works down-level
                if (args is ToastNotificationActivatedEventArgsCompat toastArgs)
                {
                    MessageBox.Show("Toast activated: " + toastArgs.Argument);
                }
            });
        }

        private void ReunionApp_OnBackgroundActivated(Windows.ApplicationModel.Activation.BackgroundActivatedEventArgs args)
        {

        }
    }
}
