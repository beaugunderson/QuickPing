namespace QuickPing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                Properties["Arguments"] = e.Args[0];
            }
            
            base.OnStartup(e);
        }
    }
}
