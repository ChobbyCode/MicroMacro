

using MicroMacro.Sdk.Menu;

namespace MicroMacro.Sdk
{
    /// <summary>
    /// Basis of the entire Plugin. This determines what happens in the entire application
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// This is the title that the Plugin will appear as
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Describe what your Plugin will do
        /// </summary>
        string Description { get; }
        
        /// <summary>
        /// This is called when the application starts up
        /// </summary>
        /// <param name="args">List of arguments that it starts with</param>
        void OnStart(string[]? args);

        /// <summary>
        /// This is called when the application is closed
        /// </summary>
        void OnTerminate();

        /// <summary>
        /// This is used when the user will view information on the Plugin
        /// </summary>
        IPluginMenu PluginHelpPage { get; }
    }
}
