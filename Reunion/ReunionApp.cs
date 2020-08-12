using System;
using System.IO;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;

namespace Reunion
{
    public delegate void OnActivated(IActivatedEventArgs args);
    public delegate void OnBackgroundActivated(BackgroundActivatedEventArgs args);

    public class ReunionApp
    {
        /// <summary>
        /// Event that is triggered when a notification or notification button is clicked.
        /// </summary>
        public static event OnActivated OnActivated;

        public static event OnBackgroundActivated OnBackgroundActivated;

        static ReunionApp()
        {
            InitializeManifest();

            DesktopNotificationManagerCompat.OnActivated += DesktopNotificationManagerCompat_OnActivated;
        }

        internal static void Initialize()
        {
            // Nothing... the static class initializer will take care of this
        }

        private static void DesktopNotificationManagerCompat_OnActivated(NotificationActivatiedEventArgs e)
        {
            if (OnActivated != null)
            {
                ValueSet userInput = new ValueSet();
                if (e.UserInput != null)
                {
                    foreach (var val in e.UserInput)
                    {
                        userInput.Add(val.Key, val.Value);
                    }
                }

                OnActivated(new ToastNotificationActivatedEventArgsCompat(e.Arguments, userInput));
            }
        }

        private static void InitializeManifest()
        {
            string manifestText = GetManifestText();

            string displayName = new Regex("DisplayName=\"([^\"]+)\"").Match(manifestText).Groups[1].Value;
            string aumid = new Regex("Name=\"([^\"]+)\"").Match(manifestText).Groups[1].Value;

            DesktopNotificationManagerCompat.RegisterApplication(aumid, displayName, "C:\\icon.png");
        }

        private static string GetManifestText()
        {
            string location = Path.Combine(AppContext.BaseDirectory, "Package.appxmanifest");
            if (File.Exists(location))
            {
                return File.ReadAllText(location);
            }
            else
            {
                throw new InvalidOperationException("When using the Reunion SDK, you must have a Package.appxmanifest file at the root of your project, and the file's build action must be set to Copy to output directory. Current path: " + location);
            }
        }
    }
}
