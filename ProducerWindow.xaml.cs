using Azure.Messaging.EventHubs.Consumer;
using System.Windows;
using System.Windows.Controls;

namespace aehc;

/// <summary>
/// Interaction logic for ConsumeWindow.xaml
/// </summary>
public partial class ProducerWindow : Window
{
    private readonly EventHubConsumerClient ConsumerClient;


    public ProducerWindow(
        EventHubConsumerClient consumerClient
    )
    {
        ConsumerClient = consumerClient;
        InitializeComponent();
    }

}