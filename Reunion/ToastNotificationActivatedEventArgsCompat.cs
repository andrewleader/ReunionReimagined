using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Collections;
using Windows.System;

namespace Reunion
{
    public class ToastNotificationActivatedEventArgsCompat : IToastNotificationActivatedEventArgs, IActivatedEventArgs, IActivatedEventArgsWithUser, IApplicationViewActivatedEventArgs
    {
        public int CurrentlyShownApplicationViewId => throw new NotImplementedException();

        public ActivationKind Kind => ActivationKind.ToastNotification;

        public ApplicationExecutionState PreviousExecutionState => throw new NotImplementedException();

        public SplashScreen SplashScreen => throw new NotImplementedException();

        public string Argument { get; private set; }

        public ValueSet UserInput { get; private set; }

        public ToastNotificationActivatedEventArgsCompat(string argument, ValueSet userInput)
        {
            Argument = argument;
            UserInput = userInput;
        }

        public User User => throw new NotImplementedException();
    }
}
