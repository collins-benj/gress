using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Producer;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;

namespace gress
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartProducer(object sender, EventArgs e)
        {

            var producerDialog = new ProducerDialogPopup(useAzureCred.IsChecked);

            var result = (ProducerDialogPopupResult) await this.ShowPopupAsync(
                producerDialog,
                CancellationToken.None
            );

            // user clicked outside of box
            if (result is null) return;

            try
            {
                EventHubProducerClient client;
                if (useAzureCred.IsChecked)
                {
                    client = new EventHubProducerClient(
                        result.ConnectionStringOrNamespace,
                        result.HubName,
                        new DefaultAzureCredential()
                    );
                }
                else
                {
                    client = new EventHubProducerClient(
                        result.ConnectionStringOrNamespace,
                        result.HubName
                    );
                }

                await Navigation.PushAsync(
                    new ProducerPage(
                        client
                    )
                );
            }
            catch(Exception ex)
            {
                //SemanticScreenReader.Announce(ex.Message);

                // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-8.0#display-an-alert
                await DisplayAlert(
                    "Malformed Connection Info",
                    ex.Message,
                    "OK"
                );

            }
        }
    }

}
