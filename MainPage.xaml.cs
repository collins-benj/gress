using Azure.Messaging.EventHubs.Producer;
using CommunityToolkit.Maui.Alerts;
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
            // malformed connection string
            catch(Exception ex)
            {
                var toast = Toast.Make(
                    "Connection String & Hub Name are required."
                );

                await toast.Show();
            }


            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
