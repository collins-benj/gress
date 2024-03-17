using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System.Collections.Concurrent;

namespace gress;

public partial class ProducerPage : ContentPage
{

    private readonly EventHubProducerClient ProducerClient;

    // don't want a huge list... maybe should let a user add a custom contenttype
    private readonly string[] ContentTypes =
    {
        "application/gzip",
        "application/json",
        "application/octet-stream",
        "application/rtf",
        "text/csv",
        "text/html",
        "text/plain",
        "custom"
    };

    public ProducerPage(
        EventHubProducerClient producerClient
    )
    {
        this.ProducerClient = producerClient;
        InitializeComponent();
        this.contentTypePicker.ItemsSource = ContentTypes;
    }

    private async void OnSendEvent(
        object sender,
        EventArgs e
    )
    {

        var partitionKey = partitionKeyInput.Text ?? default;

        var contentType = (string)contentTypePicker.SelectedItem ?? default;

        var eventData = new EventData()
        {
            EventBody = new BinaryData(
                this.eventBodyInput.Text
            ),
            ContentType = contentType,
        };

        try
        {
            await ProducerClient.SendAsync(
                new[]
                {
                eventData
                },
                new SendEventOptions()
                {
                    PartitionKey = partitionKey,
                }
            );

            confirmationLabel.Text = $"Event Hub message sent as of {DateTimeOffset.Now:o}";
            confirmationLabel.IsVisible = true;
        }
        catch ( Exception ex )
        {
            // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-8.0#display-an-alert
            await DisplayAlert(
                "Send Message Failed",
                ex.Message,
                "OK"
            );
        }
    }

    private async void OnCancel(object sender, EventArgs e) =>  await Navigation.PopAsync();

}
