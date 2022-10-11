using System.Collections.Generic;

namespace Revert.GuitarProReader
{
    public class Track
    {
        //TODO: Metadata of track

        public int Index { get; set; }
        public string Name { get; set; }

        public bool IsDrum { get; set; }
        public int StringNumber { get; set; }

        public int[] Tuning { get; set; }

        public IList<Measure> Measures { get; set; }
        public int Capo { get; set; }

        public Track()
        {
            Measures = new List<Measure>();
            //StringNumber = 6;
        }
    }
}
