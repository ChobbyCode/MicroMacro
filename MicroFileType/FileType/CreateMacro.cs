

namespace MicroFileType.FileType
{
    public class CreateMacro
    {
        public MacroFileType _OpenMacro { get; set; }

        public CreateMacro(MacroFileType _om)
        {
            _OpenMacro = _om;
        }

        public CreateMacro()
        {
            _OpenMacro = new MacroFileType();
        }

        public void OpenCreateMacroWindow()
        {
            bool exit = false;
            while(!exit)
            {
                RenderCreateMacroWindow();
                Console.ReadLine();
            }
        }

        private void RenderCreateMacroWindow()
        {
            int itemVal = 1;
            foreach (IndividualMacro m in _OpenMacro.Macros)
            {
                Console.WriteLine($"({itemVal}) - Macro: '{m.MacroText}'");
                itemVal++;
            }
            Console.WriteLine();

            Console.WriteLine("(a) - Create New");
            Console.WriteLine("(b) - Modify Existing");
        }
    }
}
