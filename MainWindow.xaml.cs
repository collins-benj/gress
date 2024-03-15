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

    public async void Click_StartProducer(
        object sender,
        RoutedEventArgs e
    )
    {
        var dialog = new ProducerDialogWindow();

        if (!dialog.ShowDialog() ?? false) return;

        var producerClient = new EventHubProducerClient(
            dialog.connectionStringTextBox.Text,
            dialog.hubNameTextBox.Text
        );

        var consumeWindow = new ProducerWindow(
            producerClient
        );

        consumeWindow.Show();
    }

}