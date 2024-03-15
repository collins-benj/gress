using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System.Windows;

namespace aehc;

/// <summary>
/// Interaction logic for ProducerWindow.xaml
/// </summary>
public partial class ProducerWindow : Window
{
    private readonly EventHubProducerClient ProducerClient;

    public ProducerWindow(
        EventHubProducerClient producerClient
    )
    {
        ProducerClient = producerClient;
        InitializeComponent();
        fullyQualifiedNameSpaceBox.Text = $"{producerClient.FullyQualifiedNamespace}/{producerClient.EventHubName}";
    }

    private async void Click_SendButton(
        object sender,
        RoutedEventArgs e
    )
    {
        var eventData = new EventData()
        {
            EventBody = new BinaryData(
                eventBodyBox.Text
            )
        };

        await ProducerClient.SendAsync(
            new[]
            {
                eventData
            }
        );
    }

    private void Click_StopButton(
        object sender,
        RoutedEventArgs e
    )
    {

    }

    private void Click_ClearButton(
        object sender,
        RoutedEventArgs e
    )
    {

    }

}