using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using System.Windows;
using System.Windows.Controls;

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
        fullyQualifiedNameSpaceBox.Text = producerClient.FullyQualifiedNamespace;
    }

}