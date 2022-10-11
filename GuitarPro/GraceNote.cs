namespace Revert.GuitarProReader.GuitarPro
{
    public class GraceNote
    {
        public Duration Duration { get; set; }
        public Dynamic Dynamic { get; set; }
        public int Fret { get; set; }
        public GraceNoteTransition Transition { get; set; }
    }
}
