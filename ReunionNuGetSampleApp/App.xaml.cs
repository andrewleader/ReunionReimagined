using Reunion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Notifications;
using Microsoft.UI.Notifications;

namespace ReunionNuGetSampleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ReunionApp.OnActivated += ReunionApp_OnActivated;

            ToastNotifier notifier;
        }

        private void ReunionApp_OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs args)
        {
            Dispatcher.Invoke(delegate
            {
                MessageBox.Show((args as ToastNotificationActivatedEventArgsCompat).Argument);
            });
        }
    }
}
