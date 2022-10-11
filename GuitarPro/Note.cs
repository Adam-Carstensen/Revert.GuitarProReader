using System.Diagnostics;

namespace Revert.GuitarProReader.GuitarPro
{
    [DebuggerDisplay("{FretNumber}")]
    public class Note
    {
        internal byte Header { get; set; }

        public Duration Duration { get; set; }
        public EffectsOnNote Effects { get; set; }
        public Fingering FingeringLeftHand { get; set; }
        public Fingering FingeringRightHand { get; set; }
        public bool IsAccentuated { get; set; }

        //Whether the note is a dotted note.
        public bool IsDotted { get; set; }

        //The note dynamic.
        public Dynamic Dynamic { get; set; }

        //The number of the fret.
        public int FretNumber { get; set; }

        //Whether the note is a dead note (displayed X).
        public bool IsDeadNote { get; set; }

        //Whether the note is a ghost note.
        public bool IsGhostNote { get; set; }

        //Whether the note is a tied note.
        public bool IsTieNote { get; set; }

        //The n-tuplet this note may take part in.
        public int NTuplet { get; set; }

        public Note()
        {
            FingeringLeftHand = Fingering.NoFinger;
            FingeringRightHand = Fingering.NoFinger;
        }

        public override string ToString()
        {
            return FretNumber.ToString();
        }
    }
}
