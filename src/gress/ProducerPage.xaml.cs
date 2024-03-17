using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System.Collections.ObjectModel;

namespace gress;

public partial class ProducerPage : ContentPage
{

    private readonly EventHubProducerClient ProducerClient;

    public readonly string[] ContentTypes =
    {
        "application/gzip",
        "application/json",
        "application/octet-stream",
        "application/rtf",
        "text/csv",
        "text/html",
        "text/plain",
        // don't want a huge list... should let a user add a custom contenttype
        "custom"
    };

    public ObservableCollection<KeyValuePair<string, string>> Properties { get; set; }

    private IEnumerable<string> PropertyKeys => Properties.Select( x => x.Key); 

    //private IEnumerable<string> PropertiesDisplay => Properties.Select(
    //    kv => $"{kv.Key} : {kv.Value}"  
    //);

    public ProducerPage(
        EventHubProducerClient producerClient
    )
    {
        this.Properties = new ObservableCollection<KeyValuePair<string, string>>();
        this.ProducerClient = producerClient;
        InitializeComponent();
        this.contentTypePicker.ItemsSource = ContentTypes;
        this.propertiesDisplayList.ItemsSource = Properties;
        this.BindingContext = this;
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
                this.eventBodyInput.Text ?? string.Empty
            ),
            ContentType = contentType,
        };


        foreach(var prop in  this.Properties) 
        {
            eventData.Properties.Add(
                prop.Key,
                prop.Value
            );
        }

        try
        {
            await ProducerClient.SendAsync(
                [
                    eventData
                ],
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

    private async void OnCancel(object sender, EventArgs e) => await Navigation.PopAsync();

    private async void OnAddProperty(object sender, EventArgs e)
    {
        var key = this.propertyKeyEntry.Text ?? default;
        var value = this.propertyValueEntry.Text ?? default;
        
        if( key is null 
            ||
            value is null
            ||
            key == string.Empty
            ||
            value == string.Empty
        ) return;

        if (PropertyKeys.Contains(key))
        {
            await DisplayAlert(
                "Error",
                "Only one value per key allowed.",
                "OK"
            );
            return;
        }
        
        Properties.Add(
            new KeyValuePair<string,string>(
                key,
                value
            )
        );

        OnPropertyChanged(nameof(Properties));
        
        propertyKeyEntry.Text = default;
        propertyValueEntry.Text = default;  

    }

}
