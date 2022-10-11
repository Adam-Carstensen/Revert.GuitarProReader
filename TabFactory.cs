using System.Collections.Generic;
using System.IO;
using Revert.Core.GuitarProReader;
using Revert.Core.GuitarProReader.GuitarPro;
using Revert.GuitarProReader.GuitarPro;

namespace Revert.GuitarProReader
{
    /// <summary>
    /// Used for creating TabFile from different formats
    /// </summary>
    public class TabFactory
    {
        public static TabFile CreateFromGp(Stream stream)
        {
            var file = new TabFile();

            GuitarProFile gpFile = GuitarProFileFactory.CreateFile(stream);
            if (gpFile == null) return null;
            int tracksCount = gpFile.Body.Tracks.Length;
            int measureCount = gpFile.Body.Measures.Length;
            //tracks init
            for (int i = 0; i < tracksCount; i++)
            {
                var gpTrack = gpFile.Body.Tracks[i];
                //TODO: init track header
                var track = new Track
                {
                    Index = i,
                    Name = gpTrack.Name,
                    IsDrum = gpTrack.IsDrumsTrack,
                    StringNumber = gpTrack.StringNumber,
                    Tuning = gpTrack.StringTuning,
                    Capo = gpTrack.CapoHeight
                };

                file.Header = gpFile.Header;

                //file.Header

                for (int j = 0; j < measureCount; j++)
                {
                    var gpMeasure = gpFile.Body.Measures[j];
                    var measure = new Measure
                    {
                        NumeratorSignature = gpMeasure.NumeratorSignature,
                        DenominatorSignature = gpMeasure.DenominatorSignature,
                    };

                    foreach (var gpBeat in gpFile.Body.MeasureTrackPairs[j * tracksCount + i].Beats)
                    {
                        //TODO init beat
                        var beat = new Beat
                        {
                            Duration = (Duration)gpBeat.Duration,
                            Tuplet = gpBeat.NTuplet,
                            IsDotted = gpBeat.DottedNotes,
                            ChordDiagram = gpBeat.ChordDiagram
                        };

                        //TODO this is for 6-strings only
                        var stringCount = track.StringNumber; //  gpBeat.Strings.Length;
                        beat.Notes = new List<Note>();
                        for (int s = 0; s < stringCount; s++)
                            beat.Notes.Add(new Note { Fret = -1 });

                        int noteIndex = 0;
                        for (int stringIndex = stringCount - 1; stringIndex > 0; stringIndex--)
                        {
                            if (!gpBeat.Strings[stringIndex])
                                continue;

                            var effects = gpBeat.Notes[noteIndex].Effects ?? new EffectsOnNote();
                            beat.Notes[stringCount - stringIndex] = new Note
                            {
                                Fret = gpBeat.Notes[noteIndex].FretNumber,
                                IsLegato = effects.HammerOnPullOff,
                                Bend = effects.Bend,
                                Slide = effects.Slide
                            };
                            noteIndex++;
                        }
                        //TODO: Remove feature
                        if (stringCount > 6)
                            beat.Notes.RemoveAt(6);
                        measure.Beats.Add(beat);
                    }
                    track.Measures.Add(measure);
                }
                file.Tracks.Add(track);
            }
            return file;
        }
    }
}
