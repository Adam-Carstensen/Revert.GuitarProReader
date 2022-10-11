using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Revert.GuitarProReader.GuitarPro;

namespace Revert.GuitarProReader
{
    /// <summary>
    /// Wraps beat
    /// </summary>
    [DebuggerDisplay("{NotesString}")]
    public class Beat
    {
        //TODO: Metadata
        public Duration Duration { get; set; }
        public BeamType Beam { get; set; }
        public int Tuplet { get; set; }
        public bool IsDotted { get; set; }

        private List<Note> notes;
        public List<Note> Notes
        {
            get { return notes ?? (notes = new List<Note>()); }
            set { notes = value; }
        }

        public string NotesString
        {
            get
            {
                var notesString = string.Empty;

                for (int i = 0; i < Notes.Count; i++)
                {
                    var note = Notes[i];
                    if (note.Fret == -1)
                    {
                        notesString += "-";
                    }
                    else
                    {
                        notesString += note.Fret;
                    }
                }

                return notesString;
            }
        }

        public int Width { get; set; }
        public ChordDiagram ChordDiagram { get; set; }

        //public List<Note> Notes { get; set; }
    }
}
