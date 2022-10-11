namespace Revert.GuitarProReader.GuitarPro
{
    public class Lyrics
    {
        internal const byte LyricsCount = 5;

        public int TrackNumber { get; set; }
        public int[] MeasureNumber { get; set; }
        public string[] Lines { get; set; }
        public Lyrics()
        {
            MeasureNumber = new int[LyricsCount];
            Lines = new string[LyricsCount];
        }
    }
}
