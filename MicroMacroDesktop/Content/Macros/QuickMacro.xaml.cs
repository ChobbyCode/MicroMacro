using MicroMacroDesktop.ViewModel;

namespace MicroMacroDesktop.Content.Macros;

public partial class QuickMacro : ContentPage
{
	public QuickMacro(QuickMacroViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}