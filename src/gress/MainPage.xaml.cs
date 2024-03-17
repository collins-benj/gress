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

            var producerDialog = new ProducerDialogPopup();

            var result = (ProducerDialogPopupResult) await this.ShowPopupAsync(
                producerDialog,
                CancellationToken.None
            );

            // user clicked outside of box
            if (result is null) return;

            try
            {
                await Navigation.PushAsync(
                    new ProducerPage(
                        new EventHubProducerClient(
                            result.ConnectionString,
                            result.HubName
                        )
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
