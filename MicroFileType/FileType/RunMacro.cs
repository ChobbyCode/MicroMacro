
namespace MicroFileType.FileType
{
    public class RunMacro
    {
        public MacroFileType MFT { get; set; }

        public RunMacro(MacroFileType macro)
        {
            MFT = macro;

            Console.WriteLine($"Please wait {Convert.ToInt32(MFT.StartDelay) / 1000} seconds before the macro starts");
            Thread.Sleep(Convert.ToInt32(MFT.StartDelay));
            Run();
        }

        private void Run()
        {
            foreach (var Macro in MFT.Macros)
            {
                KeySender.Sender sender = new KeySender.Sender();
                sender.SendString(Macro.MacroText);
            }
        }
    }
}
