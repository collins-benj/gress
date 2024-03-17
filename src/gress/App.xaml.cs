namespace gress
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        // https://stackoverflow.com/a/74447826/16610401
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 800;
            const int newHeight = 650;

            window.Width = newWidth;
            window.Height = newHeight;

            window.MinimumHeight = newHeight;
            window.MinimumWidth = newWidth;

            return window;
        }

    }
}
