using System;

namespace Revert.GuitarProReader.GuitarPro
{
    public class Measure
    {
        internal byte Header { get; set; }

        public byte NumeratorSignature { get; set; }
        public byte DenominatorSignature { get; set; }
        public bool BeginRepeat { get; set; }
        public byte EndRepeat { get; set; }
        public byte NumberAltEnding { get; set; }
        public Marker PresenceMarker { get; set; }
        public Key TonalityMeasure { get; set; }
        public bool PresenceDoubleBar { get; set; }

        internal static Measure GetMeasureFromPrevious(Measure previous)
        {
            return previous == null
                       ? new Measure()
                       : new Measure()
                       {
                           DenominatorSignature = previous.DenominatorSignature,
                           NumeratorSignature = previous.NumeratorSignature,
                           TonalityMeasure = previous.TonalityMeasure
                       };
        }


    }
}
