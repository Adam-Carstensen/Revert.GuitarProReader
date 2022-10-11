using Revert.GuitarProReader.GuitarPro;
using System.Collections.Generic;

namespace Revert.GuitarProReader
{
    public class TabFile
    {
        public Header Header { get; set; }
        public IList<Track> Tracks { get; set; }
        public TabFile()
        {
            Tracks = new List<Track>();
        }
    }
}
