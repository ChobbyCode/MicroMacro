using MicroMacroDesktop.ViewModel;

namespace MicroMacroDesktop.Content.Macros;

public partial class QuickMacro : ContentPage
{
	public string bob { get; set; }

	public QuickMacro(QuickMacroViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}