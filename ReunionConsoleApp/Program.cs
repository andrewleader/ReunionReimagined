using Microsoft.Toolkit.Uwp.Notifications;
using Reunion;
using Reunion.UI.Notifications;
using System;
using Windows.UI.Notifications;

namespace ReunionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ReunionApp.OnActivated += ReunionApp_OnActivated;

            Console.WriteLine("Hello World!");

            Console.WriteLine("To receive a toast, press any key...");

            Console.ReadLine();

            var content = new ToastContentBuilder()
                .AddText("Hi! Please enter your name!")
                .AddInputTextBox("name", "Your name")
                .AddButton("Submit", ToastActivationType.Foreground, "submit")
                .AddToastActivationInfo("helloConsoleArgs", ToastActivationType.Foreground)
                .GetToastContent();

            var notif = new ToastNotification(content.GetXml());

            // Only difference here is calling the Compat API so that works down-level
            ToastNotificationManagerCompat.CreateToastNotifier().Show(notif);

            Console.WriteLine("You should try clicking the toast...");

            Console.ReadLine();
        }

        private static void ReunionApp_OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs args)
        {
            if (args is ToastNotificationActivatedEventArgsCompat toastArgs)
            {
                Console.WriteLine($"Hey {toastArgs.UserInput["name"]}! Nice to meet you!");
                Console.WriteLine("Press any key to exit.");
            }
        }
    }
}
