
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
                // Random Setup
                var rand = new Random();
                int val = rand.Next(10, 100) * Convert.ToInt32(Macro.Randomness);

                // Enter String
                EscapeCharacter(Macro.EnterString);

                // Start Delay
                Thread.Sleep(Convert.ToInt32(Macro.StartDelay) * val);

                KeySender.Sender sender = new KeySender.Sender();
                sender.SendString(Macro.MacroText, Convert.ToInt32(Macro.Randomness));

                // Escape String
                EscapeCharacter(Macro.EscapeString);

                // Re-random random
                val = rand.Next(10, 100) * Convert.ToInt32(Macro.Randomness);
                // End Delay
                Thread.Sleep(Convert.ToInt32(Macro.EndDelay) * val);
            }
        }

        private void EscapeCharacter(string input)
        {
            KeySender.Sender sender = new KeySender.Sender();
            switch (input)
            {
                case "{:e":
                    sender.SendSpecial(KeySender.Sender.Special.Enter);
                    break;
                case "{:t":
                    sender.SendSpecial(KeySender.Sender.Special.Tab);
                    break;
                case "{:s":
                    sender.SendSpecial(KeySender.Sender.Special.Space);
                    break;
            }
        }
    }
}
