namespace Revert.GuitarProReader.Json
{
    public class Measure
    {
        public int denominator { get; set; }
        public int numerator { get; set; }
        public int tempo { get; set; }
        public Beat[] beats { get; set; }
        public int repeatopen { get; set; }
        public int repeatcount { get; set; }
        public Marker marker { get; set; }
    }

}

