
namespace MicroMacro.Sdk.Menu
{
    /// <summary>
    /// This allows custom pages to be drawn for your plugin
    /// </summary>
    public interface IPluginMenu
    {
        /// <summary>
        /// This is called when the menu should be drawn
        /// </summary>
        void RenderMenu();

        /// <summary>
        /// This will process the input. You can manage how the pages work yourself.
        /// </summary>
        /// <param name="input">The option that was chosen</param>
        void ProcessInput(string input);
    }
}
