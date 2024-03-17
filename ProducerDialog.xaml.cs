using CommunityToolkit.Maui.Views;

namespace gress;

public partial class ProducerDialogPopup : Popup
{
	public ProducerDialogPopup()
	{
		InitializeComponent();
	}

	async void OnOKButtonClicked(object? sender, EventArgs e)
	{
        // from https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/popup#returning-a-result
        // seems like best practice
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        
        await CloseAsync(
            new ProducerDialogPopupResult(
                this.connectionString.Text?.Trim() ?? string.Empty,
                this.hubName.Text?.Trim() ?? string.Empty
            ),
            cts.Token
        );
    }

}

public record ProducerDialogPopupResult(
  string ConnectionString,
  string HubName
);