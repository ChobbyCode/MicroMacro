using MicroMacroDesktop.Content.Macros;

namespace MicroMacroDesktop;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(QuickMacro), typeof(QuickMacro));
    }
}
