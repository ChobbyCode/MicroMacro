
namespace MicroMacro.Sdk.Overrides
{
    /// <summary>
    /// Will override the Base Menu for quick macro
    /// </summary>
    public interface IPluginQuickMacro
    {
        /// <summary>
        /// This is called when the window will open
        /// </summary>
        void RunWindow();
    }
}
