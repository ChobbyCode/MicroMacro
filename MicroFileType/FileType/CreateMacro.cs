﻿

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
                string input = Console.ReadLine();
                if (input.ToLower() == "x") exit = true;
                ProcessInput(input);
            }
        }

        private void ProcessInput(string input)
        {
            try
            {
                int val =  Convert.ToInt32(input);
                OpenEditWindow(_OpenMacro.Macros[val - 1]);
            }
            catch
            {
                switch (input.ToLower())
                {
                    case "a":
                        _OpenMacro.Macros.Add(new IndividualMacro());
                        OpenEditWindow(_OpenMacro.Macros[_OpenMacro.Macros.Count - 1]);
                        break;
                }
            }
        }

        private void RenderCreateMacroWindow()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("---Macros---");
            Console.WriteLine();
            int itemVal = 1;
            foreach (IndividualMacro m in _OpenMacro.Macros)
            {
                Console.WriteLine($"({itemVal}) - Macro: '{m.MacroText}'");
                itemVal++;
            }
            Console.WriteLine();
            Console.WriteLine("---Controls---");
            Console.WriteLine();
            Console.WriteLine("(a) - Create New");
            //Console.WriteLine("(b) - Modify Existing");
            Console.WriteLine();
            Console.WriteLine("(x) - Return");
        }

        private void OpenEditWindow(IndividualMacro m)
        {
            bool exit = false;
            while (!exit)
            {
                RenderEditWindow(m);
                string input = Console.ReadLine();
                if (input.ToLower() == "x") exit = true;
                m = ProcessEditWindowInput(input, m);
            }
        }

        private IndividualMacro ProcessEditWindowInput(string input, IndividualMacro m)
        {
            switch(input.ToLower())
            {
                case "1":
                    Console.Clear();
                    Console.Write("Text: ");
                    m.MacroText = Console.ReadLine();
                    return m;
                case "2":
                    Console.Clear();
                    Console.Write("Start Delay: ");
                    m.StartDelay = Console.ReadLine();
                    return m;
                case "3":
                    Console.Clear();
                    Console.Write("End Delay: ");
                    m.EndDelay = Console.ReadLine();
                    return m;
                case "4":
                    Console.Clear();
                    Console.Write("Random Factor: ");
                    m.Randomness = Console.ReadLine();
                    return m;
                case "5":
                    Console.Clear();
                    Console.Write("Enter String: ");
                    m.EnterString = Console.ReadLine();
                    return m;
                case "6":
                    Console.Clear();
                    Console.Write("Escape String: ");
                    m.EscapeString = Console.ReadLine();
                    return m;
                default:
                    return m;
            }
        }

        private void RenderEditWindow(IndividualMacro m)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("---Macro Edit---");
            Console.WriteLine();

            Console.WriteLine($"(1) - Text: {m.MacroText}");

            Console.WriteLine();
            Console.WriteLine("---Delay---");
            Console.WriteLine();

            Console.WriteLine($"(2) - Start Delay: {m.StartDelay}");
            Console.WriteLine($"(3) - End Delay: {m.EndDelay}");
            Console.WriteLine($"(4) - Random Factor: {m.Randomness}");

            Console.WriteLine();
            Console.WriteLine("---Escape Characters---");
            Console.WriteLine();

            Console.WriteLine($"(5) - Enter String: {m.EnterString}");
            Console.WriteLine($"(6) - Escape String: {m.EscapeString}");

            Console.WriteLine();
            Console.WriteLine($"(x) - Return");
        }
    }
}
