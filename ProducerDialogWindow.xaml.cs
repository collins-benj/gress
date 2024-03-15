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

namespace aehc;

/// <summary>
/// Interaction logic for ConsumerDialogWindow.xaml
/// </summary>
public partial class ProducerDialogWindow : Window
{
    public ProducerDialogWindow()
    {
        InitializeComponent();
    }

    private void Click_OkButton(
        object sender,
        RoutedEventArgs e
    ) =>  DialogResult = true;
    
}