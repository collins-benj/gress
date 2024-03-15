using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Azure.Messaging.EventHubs.Consumer;

namespace aehc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    EventHubProducerClient producerClient = new EventHubProducerClient(
        "Endpoint=sb://aehc-testing.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e8lSG9bXhEENRk+AGBcOF1lOaMjkAVAUb+AEhHcwYvo=",
        "0"
    );

    public async void Click_SendEvent(
        object sender,
        RoutedEventArgs e
    )
    {
        var eventJson = $@"{{
    ""hello"": ""world"",
    ""PublishedTime"": {DateTimeOffset.Now}
}}";

        await SendSingleEvent(
            new EventData()
            {
                EventBody = new BinaryData(eventJson)
            }
        );
    }

    public async void Click_StartConsumer(
        object sender,
        RoutedEventArgs e
    )
    {
        var dialog = new ConsumerDialogWindow();

        if (!dialog.ShowDialog() ?? false) return;
        
        var consumerClient = new EventHubConsumerClient(
            dialog.consumerGroupTextBox.Text,
            dialog.connectionStringTextBox.Text,
            dialog.hubNameTextBox.Text
        );

        var consumeWindow = new ConsumerWindow(
            consumerClient
        );

        consumeWindow.Show();
    }

    public async Task SendSingleEvent(
        EventData event_,
        CancellationToken cancellationToken = default
    )
    {

        await producerClient.SendAsync(
            new[]
            {
                event_
            },
            cancellationToken
        );

    }

}