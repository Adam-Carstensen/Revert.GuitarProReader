namespace Revert.GuitarProReader.GuitarPro
{
    public class Bend
    {
        public BendType Type { get; set; }
        public int Value { get; set; }
        public BendPoint[] Points { get; set; }
    }
}
