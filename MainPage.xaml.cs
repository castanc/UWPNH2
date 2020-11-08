using Microsoft.WindowsAzure.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.PushNotifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPNotificationHubCesar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void InitNotificationsAsync()
        {
            try
            {
                /*
Endpoint=sb://deskhelpdev.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=Le83nDUo9WP67tNsNPwo4JQpHT4ax/Sp60YfhnRF+R0=
Endpoint=sb://deskhelpdev.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=e1AK4FMIdnaBlvwtjqjYgvg5YaCbXvU6UrfyQL5wdbI=
Endpoint=sb://deskhelpdev.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=TIej1gJ3RQbP3KKKhJElI/mqXnjRw4z97XibauhEbxs=
                  
                 */
                var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

                var hub = new NotificationHub("deskhelp",
                    "Endpoint=sb://deskhelpdev.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=TIej1gJ3RQbP3KKKhJElI/mqXnjRw4z97XibauhEbxs=");

                var result = await hub.RegisterNativeAsync(channel.Uri);
                channel.PushNotificationReceived += Channel_PushNotificationReceived;

                // Displays the registration ID so you know it was successful
                if (result.RegistrationId != null)
                {
                }
            }
            catch (Exception ex)
            {
                string s = "";
            }
        }

        private void Channel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        {
            if (args?.NotificationType == PushNotificationType.Toast)
            {
                string content = args.ToastNotification.Content.InnerText;
                if (string.IsNullOrWhiteSpace(args.ToastNotification?.Content?.InnerText))
                {
                    args.Cancel = true;
                }
            }
        }

    }
}
