using Revert.GuitarProReader;
using System.Collections.Generic;

namespace Revert.GuitarProReader.GuitarPro
{
    public class Beat
    {
        internal byte Header { get; set; }
        public bool EmptyBit { get; set; }
        public bool RestBit { get; set; }
        public bool DottedNotes { get; set; }
        public Duration Duration { get; set; }
        public int NTuplet { get; set; }
        public ChordDiagram ChordDiagram { get; set; }
        public string Text { get; set; }
        public EffectsOnBeat Effects { get; set; }
        public Note[] Notes { get; set; }
        public MixTableChange MixTableChange { get; set; }
        public bool[] Strings { get; set; }

        public List<KeyValuePair<GuitarString, Note>> NotesByString
        {
            get
            {
                var notesByString = new List<KeyValuePair<GuitarString, Note>>();
                int noteIndex = 0;
                for (int i = 0; i < Strings.Length; i++)
                    if (Strings[i])
                        notesByString.Add(new KeyValuePair<GuitarString, Note>((GuitarString)i, Notes[noteIndex++]));
                return notesByString;
            }
        }

        public Beat()
        {
            Strings = new bool[7];
        }
    }
}
