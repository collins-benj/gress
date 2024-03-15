using Azure.Messaging.EventHubs.Consumer;
using System.Windows;

namespace aehc;

/// <summary>
/// Interaction logic for ConsumeWindow.xaml
/// </summary>
public partial class ConsumerWindow : Window
{
    private readonly EventHubConsumerClient ConsumerClient;


    public ConsumerWindow(
        EventHubConsumerClient consumerClient
    )
    {
        ConsumerClient = consumerClient;
        InitializeComponent();
    }

    public async void Click_Start(
        object sender,
        RoutedEventArgs e
    )
    {

    }

}