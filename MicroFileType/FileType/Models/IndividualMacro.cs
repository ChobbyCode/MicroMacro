
namespace MicroFileType.FileType
{
    public class IndividualMacro
    {
        public string StartDelay { get; set; } = "0";
        public string EndDelay { get; set; } = "100";

        public string Randomness { get; set; } = "0";

        public string MacroText { get; set; } = String.Empty;

        public string EnterString { get; set; } = String.Empty;
        public string EscapeString { get; set; } = "{:e";
    }
}
