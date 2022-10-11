using Revert.Core.GuitarProReader.Json;

namespace Revert.GuitarProReader.Json
{
    public class Track
    {
        public string name { get; set; }
        public int midiindex { get; set; }
        public int volume { get; set; }
        public int stringsnum { get; set; }
        public int offset { get; set; }
        public int[] strings { get; set; }
        public Measure[] measures { get; set; }
        public int percussion { get; set; }
    }

}

