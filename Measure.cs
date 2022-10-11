using System;
using System.Collections.Generic;

namespace Revert.GuitarProReader
{
    public class Measure
    {
        //TODO: Metadata of measure

        //public int StringsNumber { get; set; } //TODO: ambiguous usage

        public byte NumeratorSignature { get; set; }
        public byte DenominatorSignature { get; set; }

        private List<Beat> beats;
        public List<Beat> Beats
        {
            get { return beats ?? (beats = new List<Beat>()); }
            set { beats = value; }
        }
    }
}
