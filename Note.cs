using Revert.GuitarProReader.GuitarPro;
using System.Diagnostics;

namespace Revert.GuitarProReader
{
    /// <summary>
    /// represents a note
    /// </summary>
    [DebuggerDisplay("Fret: {Fret == -1 ? string.Empty : Fret.ToString() }}")]
    public class Note
    {
        //TODO header

        public bool IsLegato { get; set; }
        //public bool IsDotted { get; set; }

        //public bool Bend { get; set; }
        //public bool Slide { get; set; }

        public Bend Bend { get; set; }
        public Slide Slide { get; set; }
        public int Fret { get; set; }

        public override string ToString()
        {
            return Fret == -1 ? "" : Fret.ToString();
        }
    }
}
