using Revert.GuitarProReader;

namespace Revert.GuitarProReader.Json
{
    public class Voice
    {
        public int restvoice { get; set; }
        public int duration { get; set; }
        public Note[] notes { get; set; }
        public int empty { get; set; }
        public int tuplet { get; set; }
        public int dotted { get; set; }
    }

}

