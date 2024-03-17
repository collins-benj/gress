using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace gress;

public partial class ProducerPage : ContentPage
{

    private readonly EventHubProducerClient ProducerClient;

    public ProducerPage(
        EventHubProducerClient producerClient
    )
    {
        this.ProducerClient = producerClient;
        InitializeComponent();
    }

    private async void Click_SendButton(
        object sender,
        EventArgs e
    )
    {
        var eventData = new EventData()
        {
            EventBody = new BinaryData(
                ""
            )
        };

        await ProducerClient.SendAsync(
            new[]
            {
                eventData
            }
        );
    }

}
