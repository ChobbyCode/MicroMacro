

namespace MicroFileType.FileType
{
    public class MacroFileType
    {
        public string Name { get; set; } = "New Macro";
        public string Description { get; set; } = "This is a new macro";

        public string StartDelay { get; set; } = "5000";

        public List<IndividualMacro> Macros { get; set; } = new List<IndividualMacro>();
    }
}
