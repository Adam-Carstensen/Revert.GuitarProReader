﻿namespace Revert.GuitarProReader.GuitarPro
{
    public class AddInfo
    {
        private const byte MidiChannelCount = 64;

        public int Tempo { get; set; }
        public Key Key { get; set; }
        public int Octave { get; set; }
        public MidiChannel[] MidiChannels { get; set; }

        public int MeasuresNumber { get; set; }
        public int TracksNumber { get; set; }


        public AddInfo()
        {
            MidiChannels = new MidiChannel[MidiChannelCount];
        }
    }
}
