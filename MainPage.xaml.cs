namespace gress;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    //public async void Click_StartConsumer(
    //   object sender,
    //   EventArgs e
    //)
    //{
    //    var dialog = new ConsumerDialogWindow();

    //    if (!dialog.ShowDialog() ?? false) return;

    //    var consumerClient = new EventHubConsumerClient(
    //        dialog.consumerGroupTextBox.Text,
    //        dialog.connectionStringTextBox.Text,
    //        dialog.hubNameTextBox.Text
    //    );

    //    var consumeWindow = new ConsumerWindow(
    //        consumerClient
    //    );

    //    consumeWindow.Show();
    //}

    public async void OnStartProducer(
        object sender,
        EventArgs e
    )
    {

        //var dialog = new ProducerDialogWindow();

        //if (!dialog.ShowDialog() ?? false) return;

        //var producerClient = new EventHubProducerClient(
        //    dialog.connectionStringTextBox.Text,
        //    dialog.hubNameTextBox.Text
        //);

        //var consumeWindow = new ProducerWindow(
        //    producerClient
        //);

        //consumeWindow.Show();
    }

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //    count++;

    //    if (count == 1)
    //        CounterBtn.Text = $"Clicked {count} time";
    //    else
    //        CounterBtn.Text = $"Clicked {count} times";

    //    SemanticScreenReader.Announce(CounterBtn.Text);
    //}
}
