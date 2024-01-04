using MicroMacroDesktop.Content.Macros;

namespace MicroMacroDesktop
{
    public partial class MainPage : ContentPage
    {
        public string DebugText { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(QuickMacro));
        }
    }

}
