using System.Collections.Specialized;
using System.Windows;

using QuickPingControls;

namespace QuickPing
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var address = Application.Current.Properties["Arguments"] as string ?? "127.0.0.1";

            var addresses = new StringCollection();

            addresses.Add(address);
            addresses.Add("::1");
            addresses.Add("10.2.30.1");
            addresses.Add("10.3.30.1");
            addresses.Add("10.75.6.1");

            foreach (var a in addresses)
            {
                var status = new PingStatusControl(a);

                StackPanel1.Children.Add(status);

                status.Start();
            }
        }
    }
}