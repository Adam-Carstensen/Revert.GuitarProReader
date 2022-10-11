namespace Revert.GuitarProReader.Json
{
    public class Note
    {
        public int fret { get; set; }
        public int _string { get; set; }
        public int effect { get; set; }
        public Tremolobar[] tremolobar { get; set; }
        public Bend[] bend { get; set; }
        public int grace { get; set; }
    }

}

