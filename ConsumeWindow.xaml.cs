using Azure.Messaging.EventHubs.Consumer;
using System.Windows;
using System.Windows.Controls;

namespace aehc;

/// <summary>
/// Interaction logic for ConsumeWindow.xaml
/// </summary>
public partial class ConsumeWindow : Window
{
    private readonly EventHubConsumerClient ConsumerClient;


    public ConsumeWindow(
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