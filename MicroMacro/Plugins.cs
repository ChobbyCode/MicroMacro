
using MicroMacro.Sdk;
using MicroMacro.Sdk.Menu;
using MicroMacro.Sdk.Overrides;
using System.Reflection;

namespace MicroMacro
{
    public class Plugins
    {
        public static void InitPlugins()
        {
            Console.WriteLine("Reading Plugins...");
            _plugins = ReadExtensions();

            // Print
            foreach (var plugin in _plugins)
            {
                Console.WriteLine($"{plugin.Title} | {plugin.Description}");
            }
            foreach (var plugin in _plugins)
            {
                plugin.OnStart(null);
            }
        }

        static List<IPlugin> _plugins = null;

        static List<IPlugin> ReadExtensions()
        {
            var pluginsList = new List<IPlugin>();

            // i- read dll files from the extension folder
            var files = Directory.GetFiles("Plugins", "*.dll");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            // ii- read assemblies from those files
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));

                // iii- extract classes types that implement iplugin
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) ||
                                                                typeof(IPluginQuickMacro).IsAssignableFrom(t)).ToArray();

                foreach (var pluginType in pluginTypes)
                {
                    // iv - create instance from the extracted type
                    var pluginInstance = Activator.CreateInstance(pluginType) as IPlugin;
                    pluginsList.Add(pluginInstance);
                }
            }

            return pluginsList;
        }
    }
}
